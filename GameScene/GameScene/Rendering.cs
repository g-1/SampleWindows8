using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

namespace GameScene
{
    class Rendering
    {
        private Scene _scene = null;

        public Rendering(Scene sc)
        {
            _scene = sc;
        }

        public void AddEllipse(GameObject obj)
        {
            var ellipse = new Ellipse();
            ellipse.Width = 40;
            ellipse.Height = 40;

            ellipse.RenderTransform = new TranslateTransform()
            {
                /*
                X = obj.Pos.X - _scene.Width / 2,
                Y = obj.Pos.Y - _scene.Height / 2 */
                X = obj.Pos.X - ellipse.Width / 2,
                Y = obj.Pos.Y - ellipse.Height / 2
            };

            ellipse.Fill = new SolidColorBrush(Colors.Black);

            //画面に追加
            obj.Model = ellipse;
        }
    }

}
　