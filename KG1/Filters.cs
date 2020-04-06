using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;//цвет пикселя представляется тремя компонентами(знач от 0 до 255)
using System.ComponentModel;

public class QBitmap
{
    private Bitmap _OriginBitmap;

    public int Width { get; set; }
    public int Height { get; set; }
    private void update()
    {
        Width = _OriginBitmap.Width;
        Height = _OriginBitmap.Height;
    }

    public QBitmap() { }
    public QBitmap(Bitmap OriginBitmap, bool fill = true)
    {
        if (fill)
        {
            Load(OriginBitmap);
        }
        else
        {
            _OriginBitmap = new Bitmap(OriginBitmap.Width, OriginBitmap.Height);
            update();
        }
    }
    public QBitmap(QBitmap OriginBitmap, bool fill = true)
    {
        if (fill)
        {
            Load(OriginBitmap._OriginBitmap);
        }
        else
        {
            _OriginBitmap = new Bitmap(OriginBitmap.Width, OriginBitmap.Height);
            update();
        }
    }
    public QBitmap(int SizeX, int SizeY)
    {
        _OriginBitmap = new Bitmap(SizeX, SizeY);
        update();
    }
    public void Load(Bitmap OriginBitmap)
    {
        _OriginBitmap = new Bitmap(OriginBitmap);
        update();
    }
    public void SetPixel(int x, int y, double ch)
    {
        SetPixel(x, y, QM.clamp(ch));
    }
    public void SetPixel(int x, int y, byte ch)
    {
        SetPixel(x, y, ch, ch, ch);
    }
    public void SetPixel(int x, int y, Tuple<byte, byte, byte> RGB)
    {
        _OriginBitmap.SetPixel(x, y, Color.FromArgb(RGB.Item1, RGB.Item2, RGB.Item3));
    }
    public void SetPixel(int x, int y, byte R, byte G, byte B)
    {
        _OriginBitmap.SetPixel(x, y, Color.FromArgb(R, G, B));
    }
    public void SetPixel(int x, int y, Color ARGB)
    {
        _OriginBitmap.SetPixel(x, y, ARGB);
    }
    public (byte, byte, byte) GetPixel(int x, int y)
    {
        Color RGB = _OriginBitmap.GetPixel(x, y);
        return (RGB.R, RGB.G, RGB.B);
    }
    public Bitmap Export()
    {
        return _OriginBitmap;
    }
}

// Quick Math
static class QM
{
    private const int iMIN = 0;
    private const int iMAX = 255;

    public static int clamp(int value, int min = iMIN, int max = iMAX)
    {
        return Math.Min(Math.Max(min, value), max); ;
    }

    public static byte clamp(int value)
    {
        return (byte)Math.Min(Math.Max(iMIN, value), iMAX); ;
    }

    public static byte clamp(double value)
    {
        return (byte)Math.Min(Math.Max(iMIN, value), iMAX);
    }
    public static byte clamp(double value, double min = iMIN, double max = iMAX)
    {
        return (byte)Math.Min(Math.Max(min, value), max);
    }
    public static Color Col(double ch)
    {
        ch = clamp(ch, 0, 255);
        return Color.FromArgb((byte)ch, (byte)ch, (byte)ch);
    }
    public static Color Col(int ch)
    {
        ch = clamp(ch, 0, 255);
        return Color.FromArgb(ch, ch, ch);
    }
    public static Color Col(double R, double G, double B)
    {
        return Color.FromArgb(clamp(R), clamp(G), clamp(B));
    }
    public static Color Col(int R, int G, int B)
    {
        return Color.FromArgb(clamp(R), clamp(G), clamp(B));
    }
    public static Color Col(byte ch)
    {
        return Color.FromArgb(ch, ch, ch);
    }
}

namespace KG1
{
    abstract class Filters
    {
        protected int progressOffs = 0;
        protected int progressPerc = 100;
        //вычисляет значение пикселя отфильтрованного изображения(уникальна для каждого фильтра)
        protected abstract Color calculateNewPixelColor(QBitmap sourceImage, int x, int y);

        //общая для всех фильтров часть
        public virtual QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            QBitmap resultImage = new QBitmap(sourceImage, false);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress(progressOffs + (int)((float)i / resultImage.Width * progressPerc));
                if (worker.CancellationPending)
                {
                    return null;
                }

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    };

    class InvertFilter : Filters
    {
        //переопред функцию
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            (byte R, byte G, byte B) = sourceImage.GetPixel(x, y);//Получаем каналы цвет исходного пикселя
            return QM.Col(255 - R, 255 - G, 255 - B);     //Вычисляем инверсию цвета
        }
    };

    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            (byte R, byte G, byte B) = sourceImage.GetPixel(x, y);  //Получаем значения трех каналов пикселя с координатами (x,y)
            return QM.Col(.299F * R + .587F * G + .113F * B);       //Вычисляем значение трех каналов для градации серого
        }
    }

    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            byte k = 15;
            //Получаем значения трех каналов пикселя с координатами (x,y)
            (byte R, byte G, byte B) = sourceImage.GetPixel(x, y);

            double Intensity = (.299F * R + .587F * G + .113F * B);

            R = QM.clamp(Intensity + k * 2);
            G = QM.clamp(Intensity + k / 2);
            B = QM.clamp(Intensity - k * 1);

            return QM.Col(R, G, B);
        }
    }

    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            byte k = 15;

            //Получаем значения трех каналов пикселя с координатами (x,y)
            (byte R, byte G, byte B) = sourceImage.GetPixel(x, y);

            return QM.Col(R + k, G + k, B + k);
        }
    }

    class GrayWorldFilter : Filters
    {
        /*
         * Сумма всех цветов на изображении естественной
         * сцены дает серый цвет 
         */
        new int progress = 50;
        protected double _R_;
        protected double _G_;
        protected double _B_;
        public void AvgColors(QBitmap sourceImage, BackgroundWorker worker)
        {
            double _AVG_;
            double N = sourceImage.Width * sourceImage.Height;

            _R_ = 0;
            _B_ = 0;
            _G_ = 0;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    (byte R, byte G, byte B) = sourceImage.GetPixel(i, j);

                    _R_ += R / N;
                    _G_ += G / N;
                    _B_ += B / N;
                }

                worker.ReportProgress((int)((float)i / sourceImage.Width * progress));
            }

            _AVG_ = (_R_ + _G_ + _B_) / 3.0;

            _R_ = _AVG_ / _R_;
            _G_ = _AVG_ / _G_;
            _B_ = _AVG_ / _B_;
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            //Получаем значения трех каналов пикселя с координатами (x,y)
            (byte R, byte G, byte B) = sourceImage.GetPixel(x, y);

            R = QM.clamp(R * _R_);
            G = QM.clamp(G * _G_);
            B = QM.clamp(B * _B_);

            return QM.Col(R, G, B);
        }
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            AvgColors(sourceImage, worker);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress(50 + (int)((float)i / sourceImage.Width * progress));
                if (worker.CancellationPending)
                {
                    return null;
                }

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    sourceImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return sourceImage;
        }
    }

    //Абстрактный класс для морфологических операций
    abstract class MorphologicFilters : Filters
    {
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            QBitmap resultImage = new QBitmap(sourceImage, false);
            int ImgsW = sourceImage.Width;
            int ImgsH = sourceImage.Height;

            int MaskW = Mask.SizeX;
            int MaskH = Mask.SizeY;

            for (int y = MaskH / 2; y < ImgsH - MaskH / 2; y++)
            {
                worker.ReportProgress(progressOffs + (int)(((float)y * progressPerc) / (ImgsH - MaskH)));
                if (worker.CancellationPending)
                {
                    return null;
                }

                for (int x = MaskW / 2; x < ImgsW - MaskW / 2; x++)
                {
                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }

            return resultImage;
        }
    }
    // расширение
    class DilationFilter : MorphologicFilters
    {
        public DilationFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            int MaskW = Mask.SizeX;
            int MaskH = Mask.SizeY;

            byte maxR = 0;
            byte maxG = 0;
            byte maxB = 0;

            int MWHalf = MaskW / 2;
            int MHHalf = MaskH / 2;

            for (int j = -MHHalf; j <= MHHalf; j++)
            {
                for (int i = -MWHalf; i <= MWHalf; i++)
                {
                    (byte R, byte G, byte B) = sourceImage.GetPixel(x + i, y + j);

                    if ((Mask.map[MWHalf + i, MHHalf + j]) && (R > maxR))
                    {
                        maxR = R;
                    }

                    if ((Mask.map[MWHalf + i, MHHalf + j]) && (G > maxG))
                    {
                        maxG = G;
                    }

                    if ((Mask.map[MWHalf + i, MHHalf + j]) && (B > maxB))
                    {
                        maxB = B;
                    }
                }
            }

            return QM.Col(maxR, maxG, maxB);
        }
    }

    //  Сужение
    class ErosionFilter : MorphologicFilters
    {
        public ErosionFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            int MaskW = Mask.SizeX;
            int MaskH = Mask.SizeY;

            byte minR = 255;
            byte minG = 255;
            byte minB = 255;

            int MWHalf = MaskW / 2;
            int MHHalf = MaskH / 2;

            for (int j = -MHHalf; j <= MHHalf; j++)
            {
                for (int i = -MWHalf; i <= MWHalf; i++)
                {
                    (byte R, byte G, byte B) = sourceImage.GetPixel(x + i, y + j);

                    if ((Mask.map[i + MWHalf, j + MHHalf]) && (R < minR))
                    {
                        minR = R;
                    }

                    if ((Mask.map[i + MWHalf, j + MHHalf]) && (G < minG))
                    {
                        minG = G;
                    }

                    if ((Mask.map[i + MWHalf, j + MHHalf]) && (B < minB))
                    {
                        minB = B;
                    }
                }
            }

            return QM.Col(minR, minG, minB);
        }
    }

    class OpeningFilter : MorphologicFilters
    {
        public OpeningFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            return new Color();
        }
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            int percentage = 50 * progressPerc / 100;

            sourceImage = (new ErosionFilter(percentage, progressOffs)).processImage(sourceImage, worker);
            sourceImage = (new DilationFilter(percentage, progressOffs + percentage)).processImage(sourceImage, worker);

            return sourceImage;
        }
    }

    class ClosingFilter : MorphologicFilters
    {
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            return new Color();
        }
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            int percentage = 50 * progressPerc / 100;

            sourceImage = (new DilationFilter(percentage, progressOffs)).processImage(sourceImage, worker);
            sourceImage = (new ErosionFilter(percentage, progressOffs + percentage)).processImage(sourceImage, worker);

            return sourceImage;
        }
    }

    class SubstractionFilter : Filters
    {
        QBitmap maskImage = null;
        public SubstractionFilter(QBitmap mask, int persentage = 100, int offset = 0)
        {
            maskImage = mask;

            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            (byte oR, byte oG, byte oB) = maskImage.GetPixel(QM.clamp(x, 0, maskImage.Width), QM.clamp(y, 0, maskImage.Height));
            (byte pR, byte pG, byte pB) = sourceImage.GetPixel(x, y);

            byte R = QM.clamp(oR - pR);
            byte G = QM.clamp(oG - pG);
            byte B = QM.clamp(oB - pB);

            return QM.Col(R, G, B);
        }
    }

    class TopHat : MorphologicFilters
    {
        public TopHat(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            return new Color();
        }
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            int percentage = 50 * progressPerc / 100;

            SubstractionFilter Operator = new SubstractionFilter(sourceImage, percentage, progressOffs);
            OpeningFilter openingFilter = new OpeningFilter(percentage, progressOffs + percentage);
            QBitmap openingImage = openingFilter.processImage(sourceImage, worker);
            return Operator.processImage(openingImage, worker);
        }
    }

    abstract class MatrixFilters : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilters() { }
        public MatrixFilters(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double resultR = 0;
            double resultG = 0;
            double resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    // Значение по X
                    int idX = QM.clamp(x + k, 0, sourceImage.Width - 1);
                    // Значение по Y
                    int idY = QM.clamp(y + l, 0, sourceImage.Height - 1);

                    // Каналы в точки X,Y
                    (byte R, byte G, byte B) = sourceImage.GetPixel(idX, idY);


                    // kernel[0...radiusX, 0...radiusY]
                    // Двумерная свертка
                    resultR += R * kernel[k + radiusX, l + radiusY];
                    resultG += G * kernel[k + radiusX, l + radiusY];
                    resultB += B * kernel[k + radiusX, l + radiusY];
                }
            }

            return QM.Col(resultR, resultG, resultB);
        }
    }

    class BlurFilter : MatrixFilters
    {
        public BlurFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);

            int sizeX = 3;
            int sizeY = 3;

            kernel = new float[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            }
        }
    };

    class GaussianFilter : MatrixFilters
    {
        public GaussianFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);

            createGaussianKernel(3, 2);
        }
        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {
                    norm += kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm;
                }
            }
        }
    }

    class SobelXFilter : MatrixFilters
    {
        private const int size = 3;
        public SobelXFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);

            kernel = new float[size, size];

            kernel[0, 0] = -1.0f; kernel[0, 1] = +0.0f; kernel[0, 2] = +1.0f;
            kernel[1, 0] = -2.0f; kernel[1, 1] = +0.0f; kernel[1, 1] = +2.0f;
            kernel[2, 0] = -1.0f; kernel[2, 1] = +0.0f; kernel[2, 2] = +1.0f;
        }
    }

    class SobelYFilter : MatrixFilters
    {
        private const int size = 3;
        public SobelYFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);

            kernel = new float[size, size];

            kernel[0, 0] = -1.0f; kernel[0, 1] = -2.0f; kernel[0, 2] = -1.0f;
            kernel[1, 0] = +0.0f; kernel[1, 1] = +0.0f; kernel[1, 1] = +0.0f;
            kernel[2, 0] = +1.0f; kernel[2, 1] = +2.0f; kernel[2, 2] = +1.0f;
        }
    }


    class SobelFilter : MatrixFilters
    {
        public SobelFilter(int persentage = 100)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
        }
        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            int percentage = 33 * progressPerc / 100;

            QBitmap SobelXImage = (new SobelXFilter(percentage, 0)).processImage(sourceImage, worker);
            QBitmap SobelYImage = (new SobelYFilter(percentage, percentage)).processImage(sourceImage, worker);

            QBitmap resultImage = new QBitmap(sourceImage, false);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress(2 * percentage + (int)((float)i / resultImage.Width * percentage));//сигнализирует элементу BackgroundWorker о текущем процессе
                if (worker.CancellationPending)
                {
                    return null;
                }

                for (int j = 0; j < sourceImage.Height; j++)
                {
                    (byte xR, byte xG, byte xB) = SobelXImage.GetPixel(i, j);
                    (byte yR, byte yG, byte yB) = SobelYImage.GetPixel(i, j);

                    double dch = 0;

                    dch += xR * xR;
                    dch += xG * xG;
                    dch += xB * xB;

                    dch += yR * yR;
                    dch += yG * yG;
                    dch += yB * yB;

                    resultImage.SetPixel(i, j, Math.Sqrt(dch));
                }
            }

            return resultImage;
        }
    };

    class SharaFilter : MatrixFilters
    {
        public SharaFilter()
        {
            kernel = new float[3, 3];
            kernel[0, 0] = +3; kernel[1, 0] = 0; kernel[2, 0] = -3;
            kernel[0, 1] = +10; kernel[1, 1] = 0; kernel[2, 1] = -10;
            kernel[0, 2] = +3; kernel[1, 2] = 0; kernel[2, 2] = -3;
        }
    };

    //Резкость
    class SharpnessFilter : MatrixFilters
    {
        public SharpnessFilter()
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    kernel[i, j] = 9.0F * (i * j == 1 ? 1 : 0) - 1.0F * (i * j == 1 ? 0 : 1);
                }
            }
        }
    }

    class MedianaFilter : Filters
    {
        public MedianaFilter(int persentage = 100, int offset = 0)
        {
            progressPerc = QM.clamp(persentage, 0, 100);
            progressOffs = QM.clamp(offset, 0, 100 - progressPerc);
        }
        protected override Color calculateNewPixelColor(QBitmap sourceImage, int x, int y)
        {
            int ImgsW = sourceImage.Width;
            int ImgsH = sourceImage.Height;
            int Radius = 2;

            double _R_ = 0;
            double _G_ = 0;
            double _B_ = 0;

            double Z = 1.0 / Math.Pow(Radius, 4);

            for (int i = QM.clamp(x - Radius, 0, ImgsW); i < QM.clamp(x + Radius, 0, ImgsW); i++)
            {
                double _R = 0;
                double _G = 0;
                double _B = 0;

                for (int j = QM.clamp(y - Radius, 0, ImgsH); j < QM.clamp(y + Radius, 0, ImgsH); j++)
                {
                    (byte R, byte G, byte B) = sourceImage.GetPixel(i, j);

                    _R += R;
                    _G += G;
                    _B += B;
                }

                _R_ += _R * Z;
                _G_ += _G * Z;
                _B_ += _B * Z;
            }

            return QM.Col(_R_, _G_, _B_);
        }

        public override QBitmap processImage(QBitmap sourceImage, BackgroundWorker worker)
        {
            int ImgsW = sourceImage.Width;
            int ImgsH = sourceImage.Height;

            for (int x = 0; x < ImgsW; x++)
            {
                worker.ReportProgress((int)((float)x / (ImgsW) * progressPerc));
                if (worker.CancellationPending)
                {
                    return null;
                }

                for (int y = 0; y < ImgsH; y++)
                {
                    sourceImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }

            return sourceImage;
        }
    }
}