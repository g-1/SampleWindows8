using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;


namespace GameScene
{
    class GameObject
    {
        private Point _pos = new Point();
        public Point Pos
        {
            get
            {
                return _pos;
            }
            set
            {
                _pos = value;
            }
        }

        private Shape _model;
        public Shape Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                _model.PointerPressed += _model_PointerPressed;
            }

        }

        private bool _isLiving = true;
        public bool IsLiving
        {
            get
            {
                return _isLiving;
            }
        }

        void _model_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            this.RemoveModel();
        }
        
        public GameObject()
        {
        }

        public void Update()
        {
            if (_model == null)
            {
                _isLiving = false;
            }
        }

        private void RemoveModel()
        {
            ((Canvas)_model.Parent).Children.Remove(_model);
            _model = null;
        }
    }
}
