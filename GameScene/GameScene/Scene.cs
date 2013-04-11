using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;

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

        public void RemoveGameObject(GameObject obj)
        {
            _objList.Remove(obj);
        }

        public void Update()
        {
            //

            //
            foreach(var obj in _objList)
            {
                obj.Update();
            }

            //生存確認
            for (int i = _objList.Count - 1; i >= 0; --i)
            {
                if (!_objList[i].IsLiving)
                {
                    _objList.Remove(_objList[i]);
                }
            }
        }

        void CreateRandomObject()
        {
            //生成する
            var rand = new Random();
            int x = rand.Next(0, (int)_canvas.ActualWidth);
            int y = rand.Next(0, (int)_canvas.ActualHeight);

            var obj = new GameObject();
            obj.Pos = new Point((double)x, (double)y);

            this.AddGameObject(obj);
        }
    }
}
