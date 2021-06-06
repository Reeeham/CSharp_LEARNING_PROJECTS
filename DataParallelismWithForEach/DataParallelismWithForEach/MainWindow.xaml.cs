using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Be sure you have these namespaces!
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();


        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
        }
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles()
        {
            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all *.jpg files, and make a new folder for the modified data.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            // Process the image data in a blocking manner.
            // Process the image data in a parallel manner!
            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                  {
                      parOpts.CancellationToken.ThrowIfCancellationRequested();

                      string fileName = System.IO.Path.GetFileName(currentFile);

                      using (Bitmap bitmap = new Bitmap(currentFile))
                      {
                          bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                          bitmap.Save(System.IO.Path.Combine(newDir, fileName));
                    // Print out the ID of the thread processing the current image.
                    // This code statement is now a problem! See next section.
                    //If secondary threads attempt to access a control they did not directly create
                    //you are bound to run into runtime errors when debugging your software
                    // Eek! This will not work anymore!
                    //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                    // Invoke on the Form object, to allow secondary threads to access controls
                    // in a thread-safe manner.
                    this.Dispatcher.Invoke((Action)delegate
                          {
                              this.Title = $"Processing {fileName} on thread {Thread.CurrentThread.ManagedThreadId}";
                          });
                          this.Dispatcher.Invoke((Action)delegate
                          {
                              this.Title = "Done!";
                          });
                      }
                  }
                );
            }catch(OperationCanceledException ex)
            {
                this.Dispatcher.Invoke((Action)delegate
                {
                    this.Title = ex.Message;
                });
            }

        }
    }
}
