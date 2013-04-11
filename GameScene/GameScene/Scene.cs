using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameScene
{
    class Scene
    {
        List<GameObject> _objList = new List<GameObject>(32);
        Rendering _rendering = null;

        private Canvas _canvas = null;

        public double Width 
        {
            get
            {
                if (_canvas != null)
                {
                    return _canvas.Width;
                }
                return 0;
            }
        }
        public double Height
        {
            get
            {
                if (_canvas != null)
                {
                    return _canvas.Height;
                }
                return 0;
            }
        }

        public Canvas Canvus
        {
            set
            {
                _canvas = value;
            }

        }

        public Scene()
        {
            _rendering = new Rendering(this);
        }

        public void AddGameObject(GameObject obj)
        {
            _objList.Add(obj);

            _rendering.AddEllipse(obj);

            if (_canvas != null)
            {
                _canvas.Children.Add(obj.Model);
            }
        }
    }
}
