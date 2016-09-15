using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public partial class Component_upload: Component
    {    
        public Component_upload()
        {
            InitializeComponent();
        }

        public Component_upload(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
