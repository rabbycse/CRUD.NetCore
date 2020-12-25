using System;
using System.Collections.Generic;
using System.Linq;
using CRUD.NetCore.Data;
using CRUD.NetCore.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.NetCore.Controllers
{
    public class SalesController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() 
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult GetAllSalesData() 
        //{
        //    var sales = _unitOfWork.SalesMain.GetAll().ToList();
        //    var saleDetails = _unitOfWork.SalesSub.GetAll().ToList();

        //    var data = (from s in sales
        //                join sd in saleDetails on s.SalesMainId equals sd.SalesMainId
        //                select new
        //                { 
        //                    s.SalesMainId,
        //                    sd.ItemName,
        //                    sd.ItemRate,
        //                    sd.ItemQuantity
        //                }).ToList();
            
        //    return Ok(data);
        //}

        [HttpPost]
        public ActionResult SaveSales(SalesMain sale)
        {
            try 
            {
                sale.SalesDate = DateTime.Now;
                _unitOfWork.SalesMain.Add(sale);
                _unitOfWork.SaveChanges();
                return Ok();
                
            }
            catch (Exception x)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetSalesById(int id) 
        {
            var sale = _unitOfWork.SalesSub.Get(id);
            var data = new
            {
                sale.SalesMainId,
                sale.ItemName,
                sale.ItemRate,
                sale.ItemQuantity
            };
            return Ok(data);
        }

        [HttpPost]
        public ActionResult UpdateSales(SalesMain sale)  
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    sale.SalesDate = DateTime.Now; 
                    var existingSale = _unitOfWork.SalesMain.Get(sale.SalesMainId);
                    _unitOfWork.SalesMain.Update(existingSale);
                    _unitOfWork.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
