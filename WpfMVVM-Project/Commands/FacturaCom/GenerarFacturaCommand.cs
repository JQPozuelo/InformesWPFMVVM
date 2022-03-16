﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class GenerarFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int numProductosSeleccionados = formularioViewModel.ListaProductosC.Count();
            if (numProductosSeleccionados <= 0)
            {
                MessageBox.Show("Necesitas añadir poductos a la factura");
            }
            else
            {
                /*formularioViewModel.Factura.ListaProductosCantidadFactura = formularioViewModel.ListaProductosC;
                string dni = DataSetHandler.GetDataByDNIC(formularioViewModel.Factura.ClienteFactura.DNI);
                if (dni.Equals(""))
                {
                    MessageBox.Show("Necesitas seleccionar un cliente");
                }
                else
                {
                    formularioViewModel.Factura.ClienteFactura.DNI = dni;*/
                    bool insertarOK = DataSetHandler.insertarFactura(formularioViewModel.Factura);
                    if (!insertarOK)
                    {
                        MessageBox.Show("No se ha podido insertar");
                    }
                    else
                    {
                        MessageBox.Show("La Factura se ha registrado correctamente");
                        formularioViewModel.Factura = new FacturaModel();
                    }
                //}
            }
        }
        private FormularioViewModel formularioViewModel { set; get; }
        public GenerarFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
