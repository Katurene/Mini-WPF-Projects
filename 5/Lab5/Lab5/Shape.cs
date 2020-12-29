using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;

namespace Lab5
{
    //Подготовим объект Shape к сохранению в файл Объявим его как сериализуемый
    [Serializable]//все поля будут сохраняться целиком. Объект весь целиком помещается в файл

    public class Shape //добавить паблик к классу
    {
        //Чтобы получить возможность сериализовать данные о цвете, нам придется разложить цвет на составляющие
        byte[] color_background = new byte[3];//цвет раскладывается на 3 байта т.к он хранится как RGB
        byte[] color_foreground = new byte[3];

        public int Width { get; set; }
        //public SolidColorBrush Background { get; set; }//браш для рисования (кисть)

        [NonSerialized]//можно поставить только перед полем. В сокращ записи где поле скрыто(public SolidColorBrush Background { get; set; }) 
        private SolidColorBrush _background;   //поставить несериалайз нельзя Надо доставать поле

        public SolidColorBrush Background { get => _background; set => _background = value; }

        //public SolidColorBrush Foreground { get; set; }
        [NonSerialized]
        private SolidColorBrush _foreground;

        public SolidColorBrush Foreground { get => _foreground; set => _foreground = value; }

        public double X { get; set; }//координаты фигуры
        public double Y { get; set; }

        public Shape() { }//пустой конструктор обязателен

        public Shape(int Width, SolidColorBrush Background, SolidColorBrush Foreground)
        {
            this.Width = Width;
            this.Background = Background;
            this.Foreground = Foreground;
        }

        //методы, которые будут упаковывать цвет кисти в массив байтов и распаковывать
        private void PackColor()
        {
            color_background[0] = Background.Color.R;
            color_background[1] = Background.Color.G;
            color_background[2] = Background.Color.B;
            color_foreground[0] = Foreground.Color.R;
            color_foreground[1] = Foreground.Color.G;
            color_foreground[2] = Foreground.Color.B;
        }

        private void UnpackColor()
        {
            Background = new SolidColorBrush(Color.FromRgb(color_background[0], color_background[1], color_background[2]));
            Foreground = new SolidColorBrush(Color.FromRgb(color_foreground[0], color_foreground[1], color_foreground[2]));
        }

        //Добавим методы, которые будут сохранять объект в файл и загружать из файла. 
        //Используем стандартный диалог из пространства Microsoft.Win32;
        public void SaveToFile()
        {
            PackColor();//упаковываем цвет Из SolidColorBrush извлекаем цвет и помещаем в массив
            SaveFileDialog saveFileDialog = new SaveFileDialog();//создается новое диалоговое окно
            saveFileDialog.Filter = "Файлы (dat)|*.dat|Все файлы|*.*";//далее настраиваем фильтр
            if (saveFileDialog.ShowDialog() != true) return;//сдесь открывается станд диалоговое окно
            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);//созд поток созд файл
            BinaryFormatter bf = new BinaryFormatter();//файл подключается в BinaryFormatter
            bf.Serialize(fs, this);//сериализуем свой объект(this) в том файле
            fs.Close();//закрываем поток
        }

        public static Shape LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы (dat)|*.dat|Все файлы|*.*";
            if (openFileDialog.ShowDialog() != true) return null;
            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Shape shape = (Shape)bf.Deserialize(fs);
            shape.UnpackColor();
            return shape;
        }

        public override string ToString()
        {
            return $"{Width} {Background} {Foreground} {X} {Y}";
        }
    }
}
