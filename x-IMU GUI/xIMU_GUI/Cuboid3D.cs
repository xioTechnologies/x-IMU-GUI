using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace xIMU_GUI
{
    /// <summary>
    /// 3D cuboid class.
    /// </summary>
    /// <remarks>
    /// Requires Tao Framework 2.1.0 resources: Tao.OpenGl.dll and Tao.Platform.WIndows.dll.
    /// </remarks>
    class Cuboid3D
    {
        #region Variables

        private Form form;
        private SimpleOpenGlControl simpleOpenGlControl;
        private Timer timer;
        private string[] imageFiles;
        private uint[] textures;
        private float xDimHalf, yDimHalf, zDimHalf;
        private float[] transformationMatrix;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the rotation matrix describing the orientation of the cuboid.
        /// </summary>
        public float[] RotationMatrix
        {
            get
            {
                return new float[] {transformationMatrix[0],
                                    transformationMatrix[1],
                                    transformationMatrix[2],
                                    transformationMatrix[4],
                                    transformationMatrix[5],
                                    transformationMatrix[6],
                                    transformationMatrix[8],
                                    transformationMatrix[9],
                                    transformationMatrix[10]};
            }
            set
            {
                if (value.Length != 9) throw new Exception("Array must be of length 9.");
                transformationMatrix[0] = value[0];
                transformationMatrix[1] = value[1];
                transformationMatrix[2] = value[2];
                transformationMatrix[4] = value[3];
                transformationMatrix[5] = value[4];
                transformationMatrix[6] = value[5];
                transformationMatrix[8] = value[6];
                transformationMatrix[9] = value[7];
                transformationMatrix[10] = value[8];
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cuboid3D"/> class.
        /// </summary>
        /// </param>
        /// <param name="imageFilePaths">
        /// File paths of images used for 6 faces of cuboid.  Elements 0 to 5 correspond to the +X, -X, +Y, -Y, +Z, and -Z faces respectively.
        /// </param>
        public Cuboid3D(string[] imageFilePaths)
            : this(new float[] { 1, 1, 1 }, imageFilePaths)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cuboid3D"/> class.
        /// </summary>
        /// <param name="dimensions">
        /// Dimensions of cuboid.  Elements 0, 1 and 2 correspond the X, Y, and Z dimensions respectively.
        /// </param>
        /// <param name="imageFilePaths">
        /// File paths of images used for 6 faces of cuboid.  Elements 0 to 5 correspond to the +X, -X, +Y, -Y, +Z, and -Z faces respectively.
        /// </param>
        public Cuboid3D(float[] dimensions, string[] imageFilePaths)
        {
            xDimHalf = dimensions[0] / 2;
            yDimHalf = dimensions[1] / 2;
            zDimHalf = dimensions[2] / 2;
            imageFiles = imageFilePaths;

            transformationMatrix = new float[] {1.0f, 0.0f, 0.0f, 0.0f,
                                                0.0f, 1.0f, 0.0f, 0.0f,
                                                0.0f, 0.0f, 1.0f, 0.0f,
                                                0.0f, 0.0f, 0.0f, 1.0f};

            simpleOpenGlControl = new SimpleOpenGlControl();
            simpleOpenGlControl.Dock = DockStyle.Fill;
            simpleOpenGlControl.Load += new EventHandler(simpleOpenGlControl_Load);
            simpleOpenGlControl.SizeChanged += new EventHandler(simpleOpenGlControl_SizeChanged);
            simpleOpenGlControl.Paint += new PaintEventHandler(simpleOpenGlControl_Paint);

            form = new Form();
            form.Text = "3D Cuboid";
            form.ClientSize = new System.Drawing.Size(600, 480);
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.Controls.Add(simpleOpenGlControl);

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(Timer_Tick);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Shows the form.
        /// </summary>
        public void Show()
        {
            timer.Start();
            form.Show();
        }

        /// <summary>
        /// Hides the form.
        /// </summary>
        public void Hide()
        {
            timer.Stop();
            form.Hide();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Form load event to initialises OpenGL graphics.
        /// </summary>
        private void simpleOpenGlControl_Load(object sender, EventArgs e)
        {
            simpleOpenGlControl.InitializeContexts();
            simpleOpenGlControl.SwapBuffers();
            simpleOpenGlControl_SizeChanged(sender, e);

            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glEnable(Gl.GL_TEXTURE_2D);						    // Enable Texture Mapping            
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_DEPTH_TEST);						    // Enables Depth Testing
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glHint(Gl.GL_POLYGON_SMOOTH_HINT, Gl.GL_NICEST);     // Really Nice Point Smoothing

            textures = LoadTextureFromImage(imageFiles);
        }

        /// <summary>
        /// Window resize event to adjusts perspective.
        /// </summary>
        private void simpleOpenGlControl_SizeChanged(object sender, EventArgs e)
        {
            int height = simpleOpenGlControl.Size.Height;
            int width = simpleOpenGlControl.Size.Width;
            Gl.glViewport(0, 0, width, height);
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(10, (float)width / (float)height, 1.0, 250);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();
        }

        /// <summary>
        /// Form closing event to minimise form instead of close.
        /// </summary>
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        /// <summary>
        /// Timer tick event to refresh OpenGL graphics.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                simpleOpenGlControl.Refresh();
            }
        }

        /// <summary>
        /// Loads textures from files.
        /// </summary>
        /// <param name="filesNames">
        /// File paths of texture image files.
        /// </param>/// 
        private uint[] LoadTextureFromImage(string[] filesNames)
        {
            int numOfPic = filesNames.Length;
            uint[] texture = new uint[numOfPic];
            Bitmap[] bitmap = new Bitmap[numOfPic];
            BitmapData[] bitmapdata = new BitmapData[numOfPic];

            for (int im = 0; im < numOfPic; im++)
            {
                if (File.Exists(filesNames[im])) bitmap[im] = new Bitmap(filesNames[im]);
            }
            Gl.glGenTextures(numOfPic, texture);
            for (int i = 0; i < numOfPic; i++)
            {
                bitmap[i].RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rect = new Rectangle(0, 0, bitmap[i].Width, bitmap[i].Height);
                bitmapdata[i] = bitmap[i].LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[i]);
                Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);

                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int)Gl.GL_RGB, bitmap[i].Width, bitmap[i].Height, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata[i].Scan0);
                bitmap[i].UnlockBits(bitmapdata[i]);
                bitmap[i].Dispose();
            }
            return texture;
        }

        /// <summary>
        /// Redraw cuboid polygons.
        /// </summary>
        private void simpleOpenGlControl_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); // Clear screen and DepthBuffer
            Gl.glLoadIdentity();
            Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);

            Gl.glTranslatef(0, 0, -50);                                 // distance from camera
            Gl.glRotatef(-90, 1, 0, 0);                                 // x = right, y = away, z = up (on screen)

            Gl.glPushMatrix();
            Gl.glMultMatrixf(transformationMatrix);                     // apply specified homogenous transformation to cuboid

            // +'ve x face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(1, 0, 0); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glNormal3f(1, 0, 0); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(1, 0, 0); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(xDimHalf, yDimHalf, zDimHalf);
            Gl.glNormal3f(1, 0, 0); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(xDimHalf, yDimHalf, -zDimHalf);
            Gl.glEnd();

            // -'ve x face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(-1, 0, 0); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(-xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glNormal3f(-1, 0, 0); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(-xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(-1, 0, 0); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(-xDimHalf, yDimHalf, zDimHalf);
            Gl.glNormal3f(-1, 0, 0); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(-xDimHalf, yDimHalf, -zDimHalf);
            Gl.glEnd();

            // +'ve y face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0, 1, 0); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(-xDimHalf, yDimHalf, -zDimHalf);
            Gl.glNormal3f(0, 1, 0); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(-xDimHalf, yDimHalf, zDimHalf);
            Gl.glNormal3f(0, 1, 0); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(xDimHalf, yDimHalf, zDimHalf);
            Gl.glNormal3f(0, 1, 0); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(xDimHalf, yDimHalf, -zDimHalf);
            Gl.glEnd();

            // -'ve y face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0, -1, 0); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(-xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glNormal3f(0, -1, 0); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(-xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(0, -1, 0); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(0, -1, 0); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glEnd();

            // +'ve z face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[4]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0, 0, 1); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(-xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(0, 0, 1); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(xDimHalf, -yDimHalf, zDimHalf);
            Gl.glNormal3f(0, 0, 1); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(xDimHalf, yDimHalf, zDimHalf);
            Gl.glNormal3f(0, 0, 1); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(-xDimHalf, yDimHalf, zDimHalf);
            Gl.glEnd();

            // -'ve z face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[5]);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3f(0, 0, -1); Gl.glTexCoord2f(0, 1); Gl.glVertex3f(-xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glNormal3f(0, 0, -1); Gl.glTexCoord2f(1, 1); Gl.glVertex3f(xDimHalf, -yDimHalf, -zDimHalf);
            Gl.glNormal3f(0, 0, -1); Gl.glTexCoord2f(1, 0); Gl.glVertex3f(xDimHalf, yDimHalf, -zDimHalf);
            Gl.glNormal3f(0, 0, -1); Gl.glTexCoord2f(0, 0); Gl.glVertex3f(-xDimHalf, yDimHalf, -zDimHalf);
            Gl.glEnd();

            Gl.glPopMatrix();
            Gl.glFlush();
        }

        #endregion
    }
}