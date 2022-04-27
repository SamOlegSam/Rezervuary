using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using Reservuary.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Data.Entity.Validation;
using Newtonsoft.Json;

namespace Reservuary.Controllers
{
    public class TablesS
    {
        public int LOCAT;
        public int tankID;
        public string TANKNAME;
        public string OPCTAG;
        public double? UROVEN;
        public double V20;
        public double TEMPERAT;
        public double? V;
        public double PLOTNOST;
        public double MASSA;
        public double UROVENH2O;
        public double? VH2O;
        public double? minU;
        public decimal? minV;
        public string point;
    }


    public class HomeController : Controller
    {
        public inventorEntities db = new inventorEntities();
        public KepDataLoggerEntities db2 = new KepDataLoggerEntities();

        public ActionResult Index()
        {
            InventoryM Last = new InventoryM();
            List<InventoryM> inv = new List<InventoryM>();

            Decimal? VGomel = 0;
            DateTime? LastGom;
            Last = db.InventoryM.Where(g => g.LocID == 1).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VGomel = 0;
                LastGom = null;
            }
            else
            {
                LastGom = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastGom & f.LocID == 1).ToList();

                foreach (var i in inv)
                {
                    VGomel = VGomel + i.V20;
                }
            }

            Decimal? VZasch = 0;
            DateTime? LastZasch;
            Last = db.InventoryM.Where(g => g.LocID == 2).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VZasch = 0;
                LastZasch = null;
            }
            else
            {
                LastZasch = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastZasch & f.LocID == 2).ToList();

                foreach (var i in inv)
                {
                    VZasch = VZasch + i.V20;
                }
            }

            Decimal? VKob = 0;
            DateTime? LastKob;
            Last = db.InventoryM.Where(g => g.LocID == 3).OrderByDescending(h => h.DateInv).FirstOrDefault();

            if (Last == null)
            {
                VKob = 0;
                LastKob = null;
            }
            else
            {
                LastKob = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastKob & f.LocID == 3).ToList();
                foreach (var i in inv)
                {
                    VKob = VKob + i.V20;
                }
            }

            Decimal? VMoz = 0;
            DateTime? LastMoz;
            Last = db.InventoryM.Where(g => g.LocID == 4).OrderByDescending(h => h.DateInv).FirstOrDefault();

            if (Last == null)
            {
                VMoz = 0;
                LastMoz = null;
            }
            else
            {
                LastMoz = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastMoz & f.LocID == 4).ToList();

                foreach (var i in inv)
                {
                    VMoz = VMoz + i.V20;
                }
            }

            Decimal? VNovop = 0;
            DateTime? LastNovop;
            Last = db.InventoryM.Where(g => g.LocID == 5).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VNovop = 0;
                LastNovop = null;
            }
            else
            {
                LastNovop = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastNovop & f.LocID == 5).ToList();

                foreach (var i in inv)
                {
                    VNovop = VNovop + i.V20;
                }
            }

            Decimal? VPin = 0;
            DateTime? LastPin;
            Last = db.InventoryM.Where(g => g.LocID == 6).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VPin = 0;
                LastPin = null;
            }
            else
            {
                LastPin = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastPin & f.LocID == 6).ToList();

                foreach (var i in inv)
                {
                    VPin = VPin + i.V20;
                }
            }

            Decimal? VTur = 0;
            DateTime? LastTur;
            Last = db.InventoryM.Where(g => g.LocID == 7).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VTur = 0;
                LastTur = null;
            }
            else
            {
                LastTur = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastTur & f.LocID == 7).ToList();

                foreach (var i in inv)
                {
                    VTur = VTur + i.V20;
                }
            }

            Decimal? VGorki = 0;
            DateTime? LastGorki;
            Last = db.InventoryM.Where(g => g.LocID == 9).OrderByDescending(h => h.DateInv).FirstOrDefault();
            if (Last == null)
            {
                VGorki = 0;
                LastGorki = null;
            }
            else
            {
                LastGorki = Last.DateInv;
                inv = db.InventoryM.Where(f => f.DateInv == LastGorki & f.LocID == 9).ToList();

                foreach (var i in inv)
                {
                    VGorki = VGorki + i.V20;
                }
            }

            //----------Данные последней инвентаризации-------------------------------------
            ViewBag.VGomel = VGomel;
            ViewBag.VZasch = VZasch;
            ViewBag.VKob = VKob;
            ViewBag.VMoz = VMoz;
            ViewBag.VNovop = VNovop;
            ViewBag.VPin = VPin;
            ViewBag.VTur = VTur;
            ViewBag.VGorki = VGorki;

            //--------------Последние даты инвентаризации------------------------
            ViewBag.DateGomel = LastGom;
            ViewBag.DateZasch = LastZasch;
            ViewBag.DateKob = LastKob;
            ViewBag.DateMoz = LastMoz;
            ViewBag.DateNovop = LastNovop;
            ViewBag.DatePin = LastPin;
            ViewBag.DateTur = LastTur;
            ViewBag.DateGorki = LastGorki;
            //--------------------------------------

            Decimal? VITOG = VGomel + VZasch + VKob + VMoz + VNovop + VPin + VTur + VGorki;
            ViewBag.VITOG = VITOG;

            return View();
        }


        //----------------Подписанты--------------------------//
        public ActionResult podpisanty()
        {
            List<Podpisanty> podpisanty = new List<Podpisanty>();
            podpisanty = db.Podpisanty.OrderBy(h => h.IDFilial).ToList();

            SelectList komis = new SelectList(db.location, "id", "name");
            ViewBag.komis = komis;

            return View(podpisanty);
        }

        public ActionResult podpisantyGomel()
        {
            List<Podpisanty> podpisantyGomel = new List<Podpisanty>();
            podpisantyGomel = db.Podpisanty.Where(j => j.IDFilial == 1).OrderBy(h => h.Nazn).ToList();

            SelectList komisGomel = new SelectList(db.location, "id", "name");
            ViewBag.komisMozyr = komisGomel;

            return View(podpisantyGomel);
        }

        public ActionResult podpisantyZasch()
        {
            List<Podpisanty> podpisantyZasch = new List<Podpisanty>();
            podpisantyZasch = db.Podpisanty.Where(j => j.IDFilial == 2).OrderBy(h => h.Nazn).ToList();

            SelectList komisZasch = new SelectList(db.location, "id", "name");
            ViewBag.komisMozyr = komisZasch;

            return View(podpisantyZasch);
        }

        public ActionResult podpisantyMozyr()
        {
            List<Podpisanty> podpisantyMozyr = new List<Podpisanty>();
            podpisantyMozyr = db.Podpisanty.Where(j => j.IDFilial == 4).OrderBy(h => h.Nazn).ToList();

            SelectList komisMozyr = new SelectList(db.location, "id", "name");
            ViewBag.komisMozyr = komisMozyr;

            return View(podpisantyMozyr);
        }

        public ActionResult podpisantyTurov()
        {
            List<Podpisanty> podpisantyTurov = new List<Podpisanty>();
            podpisantyTurov = db.Podpisanty.Where(j => j.IDFilial == 7).OrderBy(h => h.Nazn).ToList();

            SelectList komisTurov = new SelectList(db.location, "id", "name");
            ViewBag.komisTurov = komisTurov;

            return View(podpisantyTurov);
        }

        public ActionResult podpisantyPinsk()
        {
            List<Podpisanty> podpisantyPinsk = new List<Podpisanty>();
            podpisantyPinsk = db.Podpisanty.Where(j => j.IDFilial == 6).OrderBy(h => h.Nazn).ToList();

            SelectList komisPinsk = new SelectList(db.location, "id", "name");
            ViewBag.komisPinsk = komisPinsk;

            return View(podpisantyPinsk);
        }

        public ActionResult podpisantyKobrin()
        {
            List<Podpisanty> podpisantyKobrin = new List<Podpisanty>();
            podpisantyKobrin = db.Podpisanty.Where(j => j.IDFilial == 3).OrderBy(h => h.Nazn).ToList();

            SelectList komisKobrin = new SelectList(db.location, "id", "name");
            ViewBag.komisKobrin = komisKobrin;

            return View(podpisantyKobrin);
        }

        public ActionResult podpisantyNovop()
        {
            List<Podpisanty> podpisantyNovop = new List<Podpisanty>();
            podpisantyNovop = db.Podpisanty.Where(j => j.IDFilial == 5).OrderBy(h => h.Nazn).ToList();

            SelectList komisNovop = new SelectList(db.location, "id", "name");
            ViewBag.komisNovop = komisNovop;

            return View(podpisantyNovop);
        }

        public ActionResult podpisantyGorki()
        {
            List<Podpisanty> podpisantyGorki = new List<Podpisanty>();
            podpisantyGorki = db.Podpisanty.Where(j => j.IDFilial == 9).OrderBy(h => h.Nazn).ToList();

            SelectList komisGorki = new SelectList(db.location, "id", "name");
            ViewBag.komisGorki = komisGorki;

            return View(podpisantyGorki);
        }
        //-----------------------------------------------------//
        public ActionResult Gomel()
        {
            List<tanks> gomel = new List<tanks>();
            gomel = db.tanks.Where(j => j.location_ID == 1).ToList();
            ViewBag.gomel = gomel;

            GomelNS1_Level_TankLeak400_1 GomelUr1 = new GomelNS1_Level_TankLeak400_1();
            GomelUr1 = db2.GomelNS1_Level_TankLeak400_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr1 = GomelUr1.value;

            GomelNS2_Level_TankLeak400_2 GomelUr2 = new GomelNS2_Level_TankLeak400_2();
            GomelUr2 = db2.GomelNS2_Level_TankLeak400_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr2 = GomelUr2.value;

            GomelNS1_Level_TankLeak100_1 GomelUr3 = new GomelNS1_Level_TankLeak100_1();
            GomelUr3 = db2.GomelNS1_Level_TankLeak100_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr3 = GomelUr3.value;

            GomelNS1_Level_TankLeak100_2 GomelUr4 = new GomelNS1_Level_TankLeak100_2();
            GomelUr4 = db2.GomelNS1_Level_TankLeak100_2.FirstOrDefault();
            ViewBag.GomelUr4 = GomelUr4.value;

            GomelScr_Level_TankLeak30 GomelUr5 = new GomelScr_Level_TankLeak30();
            GomelUr5 = db2.GomelScr_Level_TankLeak30.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr5 = GomelUr5.value;

            GomelNS1_Level_TankLeak12 GomelUr6 = new GomelNS1_Level_TankLeak12();
            GomelUr6 = db2.GomelNS1_Level_TankLeak12.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr6 = GomelUr6.value;

            GomelNS2_Level_TankLeak40_1 GomelUr7 = new GomelNS2_Level_TankLeak40_1();
            GomelUr7 = db2.GomelNS2_Level_TankLeak40_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr7 = GomelUr7.value;

            GomelNS2_Level_TankLeak40_2 GomelUr8 = new GomelNS2_Level_TankLeak40_2();
            GomelUr8 = db2.GomelNS2_Level_TankLeak40_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr8 = GomelUr8.value;

            GomelNS1_Level_TankLeak20 GomelUr9 = new GomelNS1_Level_TankLeak20();
            GomelUr9 = db2.GomelNS1_Level_TankLeak20.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr9 = GomelUr9.value;


            //GomelNS1_Level_Tank400_1 GomelUr1 = new GomelNS1_Level_Tank400_1();
            //GomelUr1 = db2.GomelNS1_Level_Tank400_1.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr1 = GomelUr1.value;
            //ViewBag.GomelNS1_Level_Tank400_1 = GomelUr1.value;
            //ViewBag.opc_TAG = GomelUr1.value;

            //GomelNS1_Level_Tank100_1 GomelUr3 = new GomelNS1_Level_Tank100_1();
            //GomelUr3 = db2.GomelNS1_Level_Tank100_1.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr3 = GomelUr3.value;

            //GomelNS1_Level_Tank100_2 GomelUr4 = new GomelNS1_Level_Tank100_2();
            //GomelUr4 = db2.GomelNS1_Level_Tank100_2.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr4 = GomelUr4.value;

            //GomelNS1_Level_TankLeak20 GomelUr5 = new GomelNS1_Level_TankLeak20();
            //GomelUr5 = db2.GomelNS1_Level_TankLeak20.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr5 = GomelUr5.value;

            //GomelScr_Level_TankLeak30 GomelUr6 = new GomelScr_Level_TankLeak30();
            //GomelUr6 = db2.GomelScr_Level_TankLeak30.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr6 = GomelUr6.value;

            //GomelNS1_Level_Tank400_1 GomelUr8 = new GomelNS1_Level_Tank400_1();
            //GomelUr8 = db2.GomelNS1_Level_Tank400_1.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr8 = GomelUr8.value;

            //GomelNS1_Level_TankLeak12 GomelUr7 = new GomelNS1_Level_TankLeak12();
            //GomelUr7 = db2.GomelNS1_Level_TankLeak12.OrderByDescending(a => a.dt).FirstOrDefault();
            //ViewBag.GomelUr7 = GomelUr7.value;

            //-----------------------------------------Вывод данных правильный Гомель---------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TGom = new TablesS();
            List<TablesS> TabGomel = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in gomel)
            {

                if (item.opc_TAG == "GomelNS1.Level.TankLeak400.1")
                {
                    UROV = GomelUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 1 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 1) == null || calibrationList.FirstOrDefault(j => j.tankid == 1) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }


                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak400.2")
                {
                    UROV = GomelUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 2 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 2) == null || calibrationList.FirstOrDefault(j => j.tankid == 2) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak100.1")
                {
                    UROV = GomelUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 3 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 3) == null || calibrationList.FirstOrDefault(j => j.tankid == 3) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak100.2")
                {

                    UROV = GomelUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 4 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 4) == null || calibrationList.FirstOrDefault(j => j.tankid == 4) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelScr.Level.TankLeak30")
                {
                    UROV = GomelUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 6 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 6) == null || calibrationList.FirstOrDefault(j => j.tankid == 6) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak12")
                {
                    UROV = GomelUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 7 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 7) == null || calibrationList.FirstOrDefault(j => j.tankid == 7) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak40_1")
                {
                    UROV = GomelUr7.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 8 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 8) == null || calibrationList.FirstOrDefault(j => j.tankid == 8) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak40_2")
                {
                    UROV = GomelUr8.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 9 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 9) == null || calibrationList.FirstOrDefault(j => j.tankid == 9) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak20")
                {
                    UROV = GomelUr9.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 62 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 62) == null || calibrationList.FirstOrDefault(j => j.tankid == 5) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 62 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 62 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 62 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 62 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabGomel.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabGomel = TabGomel;
            //-----------------------------------------------------------------------------------------------------------

            return View(gomel);
        }

        public ActionResult Zaschebe()
        {
            List<tanks> zaschebe = new List<tanks>();
            zaschebe = db.tanks.Where(j => j.location_ID == 2).ToList();
            ViewBag.zaschebe = zaschebe;

            ZaschNS1_Level_TankLeak25 ZaschUr1 = new ZaschNS1_Level_TankLeak25();
            ZaschUr1 = db2.ZaschNS1_Level_TankLeak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr1 = ZaschUr1.value;

            ZaschNS2_Level_TankLeak200_1 ZaschUr2 = new ZaschNS2_Level_TankLeak200_1();
            ZaschUr2 = db2.ZaschNS2_Level_TankLeak200_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr2 = ZaschUr2.value;

            ZaschNS2_Level_TankLeak200_2 ZaschUr3 = new ZaschNS2_Level_TankLeak200_2();
            ZaschUr3 = db2.ZaschNS2_Level_TankLeak200_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr3 = ZaschUr3.value;

            ZaschNS2_Level_TankLeak100_1 ZaschUr4 = new ZaschNS2_Level_TankLeak100_1();
            ZaschUr4 = db2.ZaschNS2_Level_TankLeak100_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr4 = ZaschUr4.value;

            ZaschNS2_Level_TankLeak100_2 ZaschUr5 = new ZaschNS2_Level_TankLeak100_2();
            ZaschUr5 = db2.ZaschNS2_Level_TankLeak100_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr5 = ZaschUr5.value;

            ZaschNS2_Level_TankLeak100_3 ZaschUr6 = new ZaschNS2_Level_TankLeak100_3();
            ZaschUr6 = db2.ZaschNS2_Level_TankLeak100_3.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr6 = ZaschUr6.value;

            //-----------------------------------------Вывод данных правильный Защебье--------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TZasch = new TablesS();
            List<TablesS> TabZasch = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in zaschebe)
            {
                if (item.opc_TAG == "ZaschNS1.Level.TankLeak25")
                {
                    UROV = ZaschUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 10 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 10) == null || calibrationList.FirstOrDefault(j => j.tankid == 10) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank200_1")
                {
                    UROV = ZaschUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 11 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 11) == null || calibrationList.FirstOrDefault(j => j.tankid == 11) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank200_2")
                {
                    UROV = ZaschUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 12 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 12) == null || calibrationList.FirstOrDefault(j => j.tankid == 12) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_1")
                {
                    UROV = ZaschUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 13 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 13) == null || calibrationList.FirstOrDefault(j => j.tankid == 13) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_2")
                {
                    UROV = ZaschUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 14 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 14) == null || calibrationList.FirstOrDefault(j => j.tankid == 14) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_3")
                {
                    UROV = ZaschUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 15 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 15) == null || calibrationList.FirstOrDefault(j => j.tankid == 15) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabZasch.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabZasch = TabZasch;
            //-----------------------------------------------------------------------------------------------------------

            return View(zaschebe);
        }
        public ActionResult Mozyr()
        {
            List<tanks> mozyr = new List<tanks>();
            mozyr = db.tanks.Where(j => j.location_ID == 4).OrderBy(g=>g.inventory_NUM).ToList();
            ViewBag.mozyr = mozyr;

            SIKN461_Level_TankLeak MozUr1 = new SIKN461_Level_TankLeak();
            MozUr1 = db2.SIKN461_Level_TankLeak.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr1 = MozUr1.value;

            MozyrBK1_Level_TankLeak25_Scr4 MozUr2 = new MozyrBK1_Level_TankLeak25_Scr4();
            MozUr2 = db2.MozyrBK1_Level_TankLeak25_Scr4.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr2 = MozUr2.value;

            MozyrNS5_Level_TankLeak461_1 MozUr3 = new MozyrNS5_Level_TankLeak461_1();
            MozUr3 = db2.MozyrNS5_Level_TankLeak461_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr3 = MozUr3.value;

            MozyrNS2_Level_TanlLeak1_2 MozUr4 = new MozyrNS2_Level_TanlLeak1_2();
            MozUr4 = db2.MozyrNS2_Level_TanlLeak1_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr4 = MozUr4.value;

            MozyrNS41_Level_TankLeak63 MozUr5 = new MozyrNS41_Level_TankLeak63();
            MozUr5 = db2.MozyrNS41_Level_TankLeak63.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr5 = MozUr5.value;

            MozyrNS3_Level_TankLeak47 MozUr6 = new MozyrNS3_Level_TankLeak47();
            MozUr6 = db2.MozyrNS3_Level_TankLeak47.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.MozUr6 = MozUr6.value;

            MozyrNS2_Level_TanlLeak25 MozUr7 = new MozyrNS2_Level_TanlLeak25();
            MozUr7 = db2.MozyrNS2_Level_TanlLeak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz7 = MozUr7.value;

            MozyrNS5_Level_TankLeak25 MozUr8 = new MozyrNS5_Level_TankLeak25();
            MozUr8 = db2.MozyrNS5_Level_TankLeak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz8 = MozUr8.value;

            MozyrBK18_Tank_Level_19 MozUr9 = new MozyrBK18_Tank_Level_19();
            MozUr9 = db2.MozyrBK18_Tank_Level_19.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz9 = MozUr9.value;

            MozyrBK18_Tank_Level_20 MozUr10 = new MozyrBK18_Tank_Level_20();
            MozUr10 = db2.MozyrBK18_Tank_Level_20.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz10 = MozUr10.value;


            //-----------------------------------------Вывод данных правильный Мозырь---------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TMoz = new TablesS();
            List<TablesS> TabMozyr = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in mozyr)
            {
                if (item.opc_TAG == "SIKN461.Level.TankLeak")
                {
                    UROV = MozUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 44 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 44) == null || calibrationList.FirstOrDefault(j => j.tankid == 44) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrBK1.Level.TankLeak25_Scr4")
                {
                    UROV = MozUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 47 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 47) == null || calibrationList.FirstOrDefault(j => j.tankid == 47) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak461_1")
                {
                    UROV = MozUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 26 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (UROV == 0 || calibrationList.LastOrDefault(g => g.tankid == 26) == null || calibrationList.FirstOrDefault(j => j.tankid == 26) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak461_2")
                {
                    UROV = MozUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 27 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 27) == null || calibrationList.FirstOrDefault(j => j.tankid == 27) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS41.Level.TankLeak63")
                {
                    UROV = MozUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 21 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 21) == null || calibrationList.FirstOrDefault(j => j.tankid == 21) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS3.Level.TankLeak47")
                {
                    UROV = MozUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 38 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 38) == null || calibrationList.FirstOrDefault(j => j.tankid == 38) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak25")
                {
                    UROV = MozUr8.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 39 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 39) == null || calibrationList.FirstOrDefault(j => j.tankid == 39) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrNS2.Level.TanlLeak25")
                {
                    UROV = MozUr7.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 24 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 24) == null || calibrationList.FirstOrDefault(j => j.tankid == 24) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrBK18.Tank.Level.19")
                {
                    UROV = MozUr9.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 45 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 45) == null || calibrationList.FirstOrDefault(j => j.tankid == 45) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrBK18.Tank.Level.20")
                {
                    UROV = MozUr10.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 46 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 46) == null || calibrationList.FirstOrDefault(j => j.tankid == 46) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }


                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabMozyr.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    point = item.point,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabMozyr = TabMozyr;
            //-----------------------------------------------------------------------------------------------------------

            return View(mozyr);
        }
        public ActionResult Turov()
        {
            List<tanks> turov = new List<tanks>();
            turov = db.tanks.Where(j => j.location_ID == 7).ToList();
            ViewBag.turov = turov;

            TurovNS2_Level_TankLeak200_1 TurUr1 = new TurovNS2_Level_TankLeak200_1();
            TurUr1 = db2.TurovNS2_Level_TankLeak200_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.TurUr1 = TurUr1.value;

            TurovNS2_Level_TankLeak200_2 TurUr2 = new TurovNS2_Level_TankLeak200_2();
            TurUr2 = db2.TurovNS2_Level_TankLeak200_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.TurUr2 = TurUr2.value;

            TurovNS2_Level_TankLeak25_1 TurUr3 = new TurovNS2_Level_TankLeak25_1();
            TurUr3 = db2.TurovNS2_Level_TankLeak25_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.TurUr3 = TurUr3.value;

            TurovNS2_Level_TankLeak25_2 TurUr4 = new TurovNS2_Level_TankLeak25_2();
            TurUr4 = db2.TurovNS2_Level_TankLeak25_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.TurUr4 = TurUr4.value;

            TurovNS1_Level_TankLeak12 TurUr5 = new TurovNS1_Level_TankLeak12();
            TurUr5 = db2.TurovNS1_Level_TankLeak12.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.TurUr5 = TurUr5.value;

            //-----------------------------------------Вывод данных правильный Туров---------------------------------------------------------------------------------------
            double? UROV = null;
            calibration VH2Calib = new calibration();
            double? VH2 = null;
            TablesS TTurov = new TablesS();
            List<TablesS> TabTurov = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in turov)
            {
                if (item.opc_TAG == "TurovNS2.Level.TankLeak200_1")
                {
                    UROV = TurUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 33 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 33) == null || calibrationList.FirstOrDefault(j => j.tankid == 33) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }

                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak200_2")
                {
                    UROV = TurUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 34 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 34) == null || calibrationList.FirstOrDefault(j => j.tankid == 34) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak25_1")
                {
                    UROV = TurUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 65 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 65) == null || calibrationList.FirstOrDefault(j => j.tankid == 65) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak25_2")
                {
                    UROV = TurUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 66 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 66) == null || calibrationList.FirstOrDefault(j => j.tankid == 66) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS1.Level.TankLeak12")
                {
                    UROV = TurUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 37 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 37) == null || calibrationList.FirstOrDefault(j => j.tankid == 37) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabTurov.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabTurov = TabTurov;
            //-----------------------------------------------------------------------------------------------------------

            return View(turov);
        }
        public ActionResult Pinsk()
        {
            List<tanks> pinsk = new List<tanks>();
            pinsk = db.tanks.Where(j => j.location_ID == 6).ToList();
            ViewBag.pinsk = pinsk;

            PinskNS2_Level_TankLeak200_1 PinUr1 = new PinskNS2_Level_TankLeak200_1();
            PinUr1 = db2.PinskNS2_Level_TankLeak200_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.PinUr1 = PinUr1.value;

            PinskNS2_Level_TankLeak200_2 PinUr2 = new PinskNS2_Level_TankLeak200_2();
            PinUr2 = db2.PinskNS2_Level_TankLeak200_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.PinUr2 = PinUr2.value;

            PinskNS2_Level_TankLeak25 PinUr3 = new PinskNS2_Level_TankLeak25();
            PinUr3 = db2.PinskNS2_Level_TankLeak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.PinUr3 = PinUr3.value;

            PinskScr_Level_TankLeak25 PinUr4 = new PinskScr_Level_TankLeak25();
            PinUr4 = db2.PinskScr_Level_TankLeak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.PinUr4 = PinUr4.value;

            PinskNS1_Level_TankLeak40 PinUr5 = new PinskNS1_Level_TankLeak40();
            PinUr5 = db2.PinskNS1_Level_TankLeak40.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.PinUr5 = PinUr5.value;

            //-----------------------------------------Вывод данных правильный Пинск--------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TPinsk = new TablesS();
            List<TablesS> TabPinsk = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in pinsk)
            {
                if (item.opc_TAG == "PinskNS2.Level.TankLeak200_1")
                {
                    UROV = PinUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 28 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 28) == null || calibrationList.FirstOrDefault(j => j.tankid == 28) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS2.Level.TankLeak200_2")
                {
                    UROV = PinUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 29 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 29) == null || calibrationList.FirstOrDefault(j => j.tankid == 29) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS2.Level.TankLeak25")
                {
                    UROV = PinUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 30 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }
                    if (calibrationList.LastOrDefault(g => g.tankid == 30) == null || calibrationList.FirstOrDefault(j => j.tankid == 30) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskScr.Level.TankLeak25")
                {
                    UROV = PinUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 31 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 31) == null || calibrationList.FirstOrDefault(j => j.tankid == 31) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS1.Level.TankLeak40")
                {
                    UROV = PinUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 32 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 32) == null || calibrationList.FirstOrDefault(j => j.tankid == 32) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabPinsk.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabPinsk = TabPinsk;
            //-----------------------------------------------------------------------------------------------------------

            return View(pinsk);
        }
        public ActionResult Kobrin()
        {
            List<tanks> kobrin = new List<tanks>();
            kobrin = db.tanks.Where(j => j.location_ID == 3).ToList();
            ViewBag.kobrin = kobrin;

            KobrinNS2_Level_TankLeak200_1 KobUr1 = new KobrinNS2_Level_TankLeak200_1();
            KobUr1 = db2.KobrinNS2_Level_TankLeak200_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr1 = KobUr1.value;

            KobrinNS2_Level_TankLeak200_2 KobUr2 = new KobrinNS2_Level_TankLeak200_2();
            KobUr2 = db2.KobrinNS2_Level_TankLeak200_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr2 = KobUr2.value;

            KobrinNS2_Level_TankLeak100_1 KobUr3 = new KobrinNS2_Level_TankLeak100_1();
            KobUr3 = db2.KobrinNS2_Level_TankLeak100_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr3 = KobUr3.value;

            KobrinNS2_Level_TankLeak100_2 KobUr4 = new KobrinNS2_Level_TankLeak100_2();
            KobUr4 = db2.KobrinNS2_Level_TankLeak100_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr4 = KobUr4.value;

            KobrinNS1_Level_TankLeak12 KobUr5 = new KobrinNS1_Level_TankLeak12();
            KobUr5 = db2.KobrinNS1_Level_TankLeak12.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr5 = KobUr5.value;

            MozAdam_km441_Level_Leak25 KobUr6 = new MozAdam_km441_Level_Leak25();
            KobUr6 = db2.MozAdam_km441_Level_Leak25.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.KobUr6 = KobUr6.value;
            //-----------------------------------------Вывод данных правильный Кобрин--------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TKobrin = new TablesS();
            List<TablesS> TabKobrin = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in kobrin)
            {
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak200_1")
                {
                    UROV = KobUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 16 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 16) == null || calibrationList.FirstOrDefault(j => j.tankid == 16) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak200_2")
                {
                    UROV = KobUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 17 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 17) == null || calibrationList.FirstOrDefault(j => j.tankid == 17) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak100_1")
                {
                    UROV = KobUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 18 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 18) == null || calibrationList.FirstOrDefault(j => j.tankid == 18) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak100_2")
                {
                    UROV = KobUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 19 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 19) == null || calibrationList.FirstOrDefault(j => j.tankid == 19) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS1.Level.TankLeak12")
                {
                    UROV = KobUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 20 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 20) == null || calibrationList.FirstOrDefault(j => j.tankid == 20) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozAdam.km441.Level.Leak25")
                {
                    UROV = KobUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 60 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 60) == null || calibrationList.FirstOrDefault(j => j.tankid == 60) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabKobrin.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV

                });
            }
            ViewBag.TabKobrin = TabKobrin;
            //-----------------------------------------------------------------------------------------------------------

            return View(kobrin);
        }
        //-------В Новополоцке нет уровнемеров---------------По крайней мере сейчас это не работает----------------------
        public ActionResult Novopolock()
        {
            List<tanks> novopolock = new List<tanks>();
            novopolock = db.tanks.Where(j => j.location_ID == 5).ToList();
            ViewBag.novopolock = novopolock;

            return View(novopolock);
        }
        public ActionResult Gorki()
        {
            List<tanks> gorki = new List<tanks>();
            gorki = db.tanks.Where(j => j.location_ID == 9).ToList();
            ViewBag.gorki = gorki;

            GorkiNS2_Level_TankLeak25_1 GorkiUr1 = new GorkiNS2_Level_TankLeak25_1();
            GorkiUr1 = db2.GorkiNS2_Level_TankLeak25_1.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GorkiUr1 = GorkiUr1.value;

            GorkiNS2_Level_TankLeak25_2 GorkiUr2 = new GorkiNS2_Level_TankLeak25_2();
            GorkiUr2 = db2.GorkiNS2_Level_TankLeak25_2.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.GorkiUr2 = GorkiUr2.value;

            //-----------------------------------------Вывод данных правильный Горки---------------------------------------------------------------------------------------
            double? UROV1 = null;

            calibration VH2Calib = new calibration();
            double? VH2 = null;
            TablesS TGorki = new TablesS();
            List<TablesS> TabGorki = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in gorki)
            {
                if (item.opc_TAG == "GorkiNS2.Level.TankLeak25_1")
                {

                    UROV1 = GorkiUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 58 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }
                    if (calibrationList.LastOrDefault(g => g.tankid == 58) == null || calibrationList.FirstOrDefault(j => j.tankid == 58) == null || UROV1 == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= UROV1).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > UROV1).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= UROV1).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > UROV1).oilvolume;
                        Upercent = ((double)UROV1 - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GorkiNS2.Level.TankLeak25_2")
                {
                    UROV1 = GorkiUr1.value;

                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 59) == null || calibrationList.FirstOrDefault(j => j.tankid == 59) == null || UROV1 == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= UROV1).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > UROV1).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= UROV1).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > UROV1).oilvolume;
                        Upercent = ((double)UROV1 - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV1 = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabGorki.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV1,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabGorki = TabGorki;
            //-----------------------------------------------------------------------------------------------------------

            return View(gorki);
        }

        //-------------------------------Вывод данных инвенторизации по филиалам------------------------------------------

        public ActionResult InventorizGomel()
        {
            List<InventoryM> InventorizGomel = new List<InventoryM>();
            InventorizGomel = db.InventoryM.Where(j => j.LocID == 1).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizGomelLast = new List<InventoryM>();

            var maxDatG = db.InventoryM.Where(k => k.LocID == 1).Max(y => y.DateInv);
            InventorizGomelLast = db.InventoryM.Where(j => j.LocID == 1 & j.DateInv == maxDatG).OrderBy(h => h.IDRez).ToList();

            SelectList inventGomel = new SelectList(db.location, "id", "name");
            ViewBag.inventGomel = InventorizGomelLast;

            List<DateTime?> datSelect = new List<DateTime?>();

            foreach (var item in InventorizGomel)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizGomelLast);
        }

        public ActionResult InventorizZaschebe()
        {
            List<InventoryM> InventorizZaschebe = new List<InventoryM>();
            InventorizZaschebe = db.InventoryM.Where(j => j.LocID == 2).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizZaschLast = new List<InventoryM>();

            var maxDatZ = db.InventoryM.Where(g => g.LocID == 2).Max(y => y.DateInv);
            InventorizZaschLast = db.InventoryM.Where(j => j.LocID == 2 & j.DateInv == maxDatZ).OrderBy(h => h.IDRez).ToList();

            SelectList inventZaschebe = new SelectList(db.location, "id", "name");
            ViewBag.inventZaschebe = InventorizZaschLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizZaschebe)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizZaschLast);
        }

        public ActionResult InventorizMozyr()
        {
            List<InventoryM> InventorizMozyr = new List<InventoryM>();
            InventorizMozyr = db.InventoryM.Where(j => j.LocID == 4).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizMozyrLast = new List<InventoryM>();

            var maxDatM = db.InventoryM.Where(g => g.LocID == 4).Max(y => y.DateInv);
            InventorizMozyrLast = db.InventoryM.Where(j => j.LocID == 4 & j.DateInv == maxDatM).OrderBy(h => h.IDRez).ToList();
            InventorizMozyrLast = InventorizMozyrLast.OrderBy(g=>g.tanks.inventory_NUM).ToList();

            SelectList inventMozyr = new SelectList(db.location, "id", "name");
            ViewBag.inventMozyr = InventorizMozyrLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizMozyr)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizMozyrLast);
        }

        public ActionResult InventorizTurov()
        {
            List<InventoryM> InventorizTurov = new List<InventoryM>();
            InventorizTurov = db.InventoryM.Where(j => j.LocID == 7).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizTurovLast = new List<InventoryM>();

            var maxDatT = db.InventoryM.Where(g => g.LocID == 7).Max(y => y.DateInv);
            InventorizTurovLast = db.InventoryM.Where(j => j.LocID == 7 & j.DateInv == maxDatT).OrderBy(h => h.IDRez).ToList();

            SelectList inventTurov = new SelectList(db.location, "id", "name");
            ViewBag.inventTurov = InventorizTurovLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizTurov)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizTurovLast);
        }

        public ActionResult InventorizPinsk()
        {
            List<InventoryM> InventorizPinsk = new List<InventoryM>();
            InventorizPinsk = db.InventoryM.Where(j => j.LocID == 6).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizPinskLast = new List<InventoryM>();

            var maxDatP = db.InventoryM.Where(g => g.LocID == 6).Max(y => y.DateInv);
            InventorizPinskLast = db.InventoryM.Where(j => j.LocID == 6 & j.DateInv == maxDatP).OrderBy(h => h.IDRez).ToList();

            SelectList inventPinsk = new SelectList(db.location, "id", "name");
            ViewBag.inventPinsk = InventorizPinskLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizPinsk)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizPinskLast);
        }

        public ActionResult InventorizKobrin()
        {
            List<InventoryM> InventorizKobrin = new List<InventoryM>();
            InventorizKobrin = db.InventoryM.Where(j => j.LocID == 3).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizKobrinLast = new List<InventoryM>();

            var maxDatK = db.InventoryM.Where(g => g.LocID == 3).Max(y => y.DateInv);
            InventorizKobrinLast = db.InventoryM.Where(j => j.LocID == 3 & j.DateInv == maxDatK).OrderBy(h => h.IDRez).ToList();

            SelectList inventKobrin = new SelectList(db.location, "id", "name");
            ViewBag.inventKobrin = InventorizKobrinLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizKobrin)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizKobrinLast);
        }

        public ActionResult InventorizNovopolock()
        {
            List<InventoryM> InventorizNovopolock = new List<InventoryM>();
            InventorizNovopolock = db.InventoryM.Where(j => j.LocID == 5).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizNovopolockLast = new List<InventoryM>();

            var maxDatN = db.InventoryM.Where(g => g.LocID == 5).Max(y => y.DateInv);
            InventorizNovopolockLast = db.InventoryM.Where(j => j.LocID == 5 & j.DateInv == maxDatN).OrderBy(h => h.IDRez).ToList();

            SelectList inventNovopolock = new SelectList(db.location, "id", "name");
            ViewBag.inventNovopolock = InventorizNovopolockLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizNovopolock)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizNovopolockLast);
        }

        public ActionResult InventorizGorki()
        {
            List<InventoryM> InventorizGorki = new List<InventoryM>();
            InventorizGorki = db.InventoryM.Where(j => j.LocID == 9).OrderByDescending(h => h.DateInv).ToList();
            List<InventoryM> InventorizGorkiLast = new List<InventoryM>();

            var maxDatG = db.InventoryM.Where(g => g.LocID == 9).Max(y => y.DateInv);
            InventorizGorkiLast = db.InventoryM.Where(j => j.LocID == 9 & j.DateInv == maxDatG).OrderBy(h => h.IDRez).ToList();

            SelectList inventGorki = new SelectList(db.location, "id", "name");
            ViewBag.inventGorki = InventorizGorkiLast;

            List<DateTime?> datSelect = new List<DateTime?>();
            foreach (var item in InventorizGorki)
            {
                datSelect.Add(item.DateInv);
            }
            List<DateTime?> datSelectDiST = new List<DateTime?>();
            datSelectDiST = datSelect.Distinct().ToList();
            ViewBag.SelectDist = datSelectDiST;

            return View(InventorizGorkiLast);
        }

        //-------------------------------
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult WriteDB(DateTime datapicker, string LocID, string IDRez, string Uroven, string V20, string Temperat, string V, string Plotnost, string massa, string UrovH2O, string VH2O, string User)
        {
            int loc = Convert.ToInt32(LocID);
            List<InventoryM> InventoryTest = new List<InventoryM>();
            InventoryTest = db.InventoryM.Where(g => g.DateInv == datapicker & g.LocID == loc).ToList();
            if (InventoryTest.Count == 0)
            {
                try
            {
                InventoryM inventM = new InventoryM();
                inventM.DateInv = Convert.ToDateTime(datapicker);
                inventM.LocID = Convert.ToInt32(LocID);
                inventM.IDRez = Convert.ToInt32(IDRez);
                inventM.Date = DateTime.Now;
                inventM.Uroven = Convert.ToDecimal(Uroven);
                inventM.V20 = Convert.ToDecimal(V20);
                //inventM.Temper = Convert.ToDecimal(Temperat);
                inventM.Temper = 0;
                inventM.Vol = Convert.ToDecimal(V);
                //inventM.Plotnost = Convert.ToDecimal(Plotnost);
                inventM.Plotnost = 0;
                //inventM.Massa = Convert.ToDecimal(massa);
                inventM.Massa = 0;
                inventM.UrovH2O = Convert.ToDecimal(UrovH2O);
                inventM.VH2O = Convert.ToDecimal(VH2O);
                //inventM.UserDC = User.Substring(1,5);
                inventM.UserDC = System.Web.HttpContext.Current.User.Identity.Name;
                
                db.InventoryM.Add(inventM);

                db.SaveChanges();

                ViewBag.Message = "Запись успешно добавлена";
            }

            //catch (Exception ex)
            //{
            //    ViewBag.Message = ex.ToString();
            //}
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    ViewBag.Message = "Object: " + validationError.Entry.Entity.ToString();
                    ViewBag.Message = "";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        //Response.Write(err.ErrorMessage + "");
                        ViewBag.Message = err.ErrorMessage + "";
                    }
                }
            }
            }
            else
            {
                ViewBag.Message = "ЗАПИСЬ НА ДАННУЮ ДАТУ УЖЕ СУЩЕСТВУЕТ";
            }

            return PartialView();
        }
        [HttpPost]
        public ActionResult ModalDB(string datapicker)
        {

            return PartialView();
        }

        //-----------------------------//

        // Редактирование члена комиссии//

        public ActionResult KomissiyaEdit(int ID)
        {
            Podpisanty pod = new Podpisanty();
            pod = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(pod);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии------------//
        [HttpPost]
        public ActionResult KomissiyaEditSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty pod = new Podpisanty();
                pod = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                pod.Nazn = Nazn.Trim();
                pod.Doljnost = Doljnost.Trim();
                pod.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Гомель//

        public ActionResult KomissiyaEditGomel(int ID)
        {
            Podpisanty podGomel = new Podpisanty();
            podGomel = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podGomel);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Гомель------------//
        [HttpPost]
        public ActionResult KomissiyaEditGomelSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podGomel = new Podpisanty();
                podGomel = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podGomel.Nazn = Nazn.Trim();
                podGomel.Doljnost = Doljnost.Trim();
                podGomel.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Защебье//

        public ActionResult KomissiyaEditZasch(int ID)
        {
            Podpisanty podZasch = new Podpisanty();
            podZasch = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podZasch);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Защебье------------//
        [HttpPost]
        public ActionResult KomissiyaEditZaschSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podZasch = new Podpisanty();
                podZasch = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podZasch.Nazn = Nazn.Trim();
                podZasch.Doljnost = Doljnost.Trim();
                podZasch.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Кобрин//

        public ActionResult KomissiyaEditKobrin(int ID)
        {
            Podpisanty podKobrin = new Podpisanty();
            podKobrin = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podKobrin);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Кобрин------------//
        [HttpPost]
        public ActionResult KomissiyaEditKobrinSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podKobrin = new Podpisanty();
                podKobrin = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podKobrin.Nazn = Nazn.Trim();
                podKobrin.Doljnost = Doljnost.Trim();
                podKobrin.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Мозырь//

        public ActionResult KomissiyaEditMozyr(int ID)
        {
            Podpisanty podMozyr = new Podpisanty();
            podMozyr = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podMozyr);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Мозырь------------//
        [HttpPost]
        public ActionResult KomissiyaEditMozyrSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podMozyr = new Podpisanty();
                podMozyr = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podMozyr.Nazn = Nazn.Trim();
                podMozyr.Doljnost = Doljnost.Trim();
                podMozyr.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Новополоцк//

        public ActionResult KomissiyaEditNovop(int ID)
        {
            Podpisanty podNovop = new Podpisanty();
            podNovop = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podNovop);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Новополоцк------------//
        [HttpPost]
        public ActionResult KomissiyaEditNovopSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podNovop = new Podpisanty();
                podNovop = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podNovop.Nazn = Nazn.Trim();
                podNovop.Doljnost = Doljnost.Trim();
                podNovop.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Пинск//

        public ActionResult KomissiyaEditPinsk(int ID)
        {
            Podpisanty podPinsk = new Podpisanty();
            podPinsk = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podPinsk);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Пинск------------//
        [HttpPost]
        public ActionResult KomissiyaEditPinskSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podPinsk = new Podpisanty();
                podPinsk = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podPinsk.Nazn = Nazn.Trim();
                podPinsk.Doljnost = Doljnost.Trim();
                podPinsk.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Туров//

        public ActionResult KomissiyaEditTurov(int ID)
        {
            Podpisanty podTurov = new Podpisanty();
            podTurov = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podTurov);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Туров------------//
        [HttpPost]
        public ActionResult KomissiyaEditTurovSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podTurov = new Podpisanty();
                podTurov = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podTurov.Nazn = Nazn.Trim();
                podTurov.Doljnost = Doljnost.Trim();
                podTurov.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        // Редактирование члена комиссии Горки//

        public ActionResult KomissiyaEditGorki(int ID)
        {
            Podpisanty podGorki = new Podpisanty();
            podGorki = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podGorki);
        }
        //-------------------------------//

        //Сохранение редактирования члена комиссии Горки------------//
        [HttpPost]
        public ActionResult KomissiyaEditGorkiSave(int ID, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty podGorki = new Podpisanty();
                podGorki = db.Podpisanty.FirstOrDefault(s => s.ID == ID);

                podGorki.Nazn = Nazn.Trim();
                podGorki.Doljnost = Doljnost.Trim();
                podGorki.FIO = FIO.Trim();
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно изменен";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        //----------Добавление члена комиссии-----------------------//

        public ActionResult AddKomissiya()
        {
            SelectList komis = new SelectList(db.location, "id", "name");
            ViewBag.komis = komis;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии-----------//
        [HttpPost]
        public ActionResult KomissiyaSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty kom = new Podpisanty();
                kom.IDFilial = Convert.ToInt32(location);
                kom.Nazn = Nazn.Trim();
                kom.Doljnost = Doljnost.Trim();
                kom.FIO = FIO.Trim();
                db.Podpisanty.Add(kom);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Гомель----------------------//

        public ActionResult AddKomissiyaGomel()
        {
            SelectList komisGomel = new SelectList(db.location, "id", "name");
            ViewBag.komisGomel = komisGomel;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Гомель-----------//
        [HttpPost]
        public ActionResult KomissiyaGomelSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komGom = new Podpisanty();
                komGom.IDFilial = 1;
                komGom.Nazn = Nazn.Trim();
                komGom.Doljnost = Doljnost.Trim();
                komGom.FIO = FIO.Trim();
                db.Podpisanty.Add(komGom);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Защебье-----------------------//

        public ActionResult AddKomissiyaZasch()
        {
            SelectList komisZasch = new SelectList(db.location, "id", "name");
            ViewBag.komisZasch = komisZasch;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Защебье-----------//
        [HttpPost]
        public ActionResult KomissiyaZaschSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komZasch = new Podpisanty();
                komZasch.IDFilial = 2;
                komZasch.Nazn = Nazn.Trim();
                komZasch.Doljnost = Doljnost.Trim();
                komZasch.FIO = FIO.Trim();
                db.Podpisanty.Add(komZasch);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Мозырь-----------------------//

        public ActionResult AddKomissiyaMozyr()
        {
            SelectList komisMozyr = new SelectList(db.location, "id", "name");
            ViewBag.komisMozyr = komisMozyr;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Мозырь-----------//
        [HttpPost]
        public ActionResult KomissiyaMozyrSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komMozyr = new Podpisanty();
                komMozyr.IDFilial = 4;
                komMozyr.Nazn = Nazn.Trim();
                komMozyr.Doljnost = Doljnost.Trim();
                komMozyr.FIO = FIO.Trim();
                db.Podpisanty.Add(komMozyr);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Туров-----------------------//

        public ActionResult AddKomissiyaTurov()
        {
            SelectList komisTurov = new SelectList(db.location, "id", "name");
            ViewBag.komisTurov = komisTurov;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Туров-----------//
        [HttpPost]
        public ActionResult KomissiyaTurovSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komTurov = new Podpisanty();
                komTurov.IDFilial = 7;
                komTurov.Nazn = Nazn.Trim();
                komTurov.Doljnost = Doljnost.Trim();
                komTurov.FIO = FIO.Trim();
                db.Podpisanty.Add(komTurov);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Пинск-----------------------//

        public ActionResult AddKomissiyaPinsk()
        {
            SelectList komisPinsk = new SelectList(db.location, "id", "name");
            ViewBag.komisPinsk = komisPinsk;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Пинск-----------//
        [HttpPost]
        public ActionResult KomissiyaPinskSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komPinsk = new Podpisanty();
                komPinsk.IDFilial = 6;
                komPinsk.Nazn = Nazn.Trim();
                komPinsk.Doljnost = Doljnost.Trim();
                komPinsk.FIO = FIO.Trim();
                db.Podpisanty.Add(komPinsk);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Кобрин-----------------------//

        public ActionResult AddKomissiyaKobrin()
        {
            SelectList komisKobrin = new SelectList(db.location, "id", "name");
            ViewBag.komisKobrin = komisKobrin;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Кобрин-----------//
        [HttpPost]
        public ActionResult KomissiyaKobrinSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komKobrin = new Podpisanty();
                komKobrin.IDFilial = 3;
                komKobrin.Nazn = Nazn.Trim();
                komKobrin.Doljnost = Doljnost.Trim();
                komKobrin.FIO = FIO.Trim();
                db.Podpisanty.Add(komKobrin);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Новополоцк-----------------------//

        public ActionResult AddKomissiyaNovop()
        {
            SelectList komisNovop = new SelectList(db.location, "id", "name");
            ViewBag.komisNovop = komisNovop;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Новополоцк-----------//
        [HttpPost]
        public ActionResult KomissiyaNovopSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komNovop = new Podpisanty();
                komNovop.IDFilial = 5;
                komNovop.Nazn = Nazn.Trim();
                komNovop.Doljnost = Doljnost.Trim();
                komNovop.FIO = FIO.Trim();
                db.Podpisanty.Add(komNovop);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//
        //----------Добавление члена комиссии Горки-----------------------//
        public ActionResult AddKomissiyaGorki()
        {
            SelectList komisGorki = new SelectList(db.location, "id", "name");
            ViewBag.komisGorki = komisGorki;
            return PartialView();
        }
        //--------------------------//
        //-----Сохранение добавления члена комиссии Горки-----------//
        [HttpPost]
        public ActionResult KomissiyaGorkiSave(string location, string Nazn, string Doljnost, string FIO)
        {
            try
            {
                Podpisanty komGorki = new Podpisanty();
                komGorki.IDFilial = 9;
                komGorki.Nazn = Nazn.Trim();
                komGorki.Doljnost = Doljnost.Trim();
                komGorki.FIO = FIO.Trim();
                db.Podpisanty.Add(komGorki);

                db.SaveChanges();

                ViewBag.Message = "Член комиссии успешно добавлендобавлен!";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }
        //----------------------------------//

        // удаление подписанта//

        public ActionResult DeletePodpis(int ID)
        {
            Podpisanty podp = new Podpisanty();
            podp = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podp);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта//
        public ActionResult DeletePodpisOK(int ID)
        {
            try
            {

                Podpisanty podpis = new Podpisanty();
                podpis = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpis);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Гомель//

        public ActionResult DeletePodpisGomel(int ID)
        {
            Podpisanty podpGomel = new Podpisanty();
            podpGomel = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpGomel);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Гомель//
        public ActionResult DeletePodpisGomelOK(int ID)
        {
            try
            {

                Podpisanty podpisGomel = new Podpisanty();
                podpisGomel = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisGomel);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Защебье//

        public ActionResult DeletePodpisZasch(int ID)
        {
            Podpisanty podpZasch = new Podpisanty();
            podpZasch = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpZasch);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Защебье//
        public ActionResult DeletePodpisZaschOK(int ID)
        {
            try
            {

                Podpisanty podpisZasch = new Podpisanty();
                podpisZasch = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisZasch);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Мозырь//

        public ActionResult DeletePodpisMozyr(int ID)
        {
            Podpisanty podpMozyr = new Podpisanty();
            podpMozyr = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpMozyr);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Мозырь//
        public ActionResult DeletePodpisMozyrOK(int ID)
        {
            try
            {

                Podpisanty podpisMozyr = new Podpisanty();
                podpisMozyr = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisMozyr);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Туров//

        public ActionResult DeletePodpisTurov(int ID)
        {
            Podpisanty podpTurov = new Podpisanty();
            podpTurov = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpTurov);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Туров//
        public ActionResult DeletePodpisTurovOK(int ID)
        {
            try
            {

                Podpisanty podpisTurov = new Podpisanty();
                podpisTurov = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisTurov);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Пинск//

        public ActionResult DeletePodpisPinsk(int ID)
        {
            Podpisanty podpPinsk = new Podpisanty();
            podpPinsk = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpPinsk);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Пинск//
        public ActionResult DeletePodpisPinskOK(int ID)
        {
            try
            {

                Podpisanty podpisPinsk = new Podpisanty();
                podpisPinsk = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisPinsk);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Кобрин//

        public ActionResult DeletePodpisKobrin(int ID)
        {
            Podpisanty podpKobrin = new Podpisanty();
            podpKobrin = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpKobrin);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Кобрин//
        public ActionResult DeletePodpisKobrinOK(int ID)
        {
            try
            {

                Podpisanty podpisKobrin = new Podpisanty();
                podpisKobrin = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisKobrin);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Новополоцк//

        public ActionResult DeletePodpisNovop(int ID)
        {
            Podpisanty podpNovop = new Podpisanty();
            podpNovop = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpNovop);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Новополоцк//
        public ActionResult DeletePodpisNovopOK(int ID)
        {
            try
            {

                Podpisanty podpisNovop = new Podpisanty();
                podpisNovop = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisNovop);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }
        // удаление подписанта Горки//

        public ActionResult DeletePodpisGorki(int ID)
        {
            Podpisanty podpGorki = new Podpisanty();
            podpGorki = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
            return PartialView(podpGorki);
        }
        //-----------------------------//

        // Подтверждение удаления подписанта Горки//
        public ActionResult DeletePodpisGorkiOK(int ID)
        {
            try
            {

                Podpisanty podpisGorki = new Podpisanty();
                podpisGorki = db.Podpisanty.FirstOrDefault(a => a.ID == ID);
                db.Podpisanty.Remove(podpisGorki);
                db.SaveChanges();

                ViewBag.Message = "Подписант успешно удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }

        //----------------Формирование отчета PDF---------------//
        public ActionResult Report(string dat, string location)
        {
            DateTime formatdat = Convert.ToDateTime(dat);
            string PredDolj;
            string PredFIO;
            string MOLFIO;
            int locat = Convert.ToInt32(location);
            //int locat = Convert.ToInt32(location);
            DateTime datInv = Convert.ToDateTime(dat);
            List<Podpisanty> kom = new List<Podpisanty>();
            kom = db.Podpisanty.Where(h => h.IDFilial == locat).ToList();
            location Fil = new location();
            Fil = db.location.FirstOrDefault(f => f.id == locat);
            string Filstr = Fil.name.Trim().ToString();

            //---------------Вывод председателя комиссии---------------------//
            Podpisanty predkom = kom.FirstOrDefault(j => j.Nazn.Trim() == "Председатель комиссии");
            if (predkom == null)
            {
                PredDolj = "";
                PredFIO = "";
            }
            else
            {
                PredDolj = predkom.Doljnost.Trim().ToString();
                PredFIO = predkom.FIO.Trim().ToString();
            }

            //------------------Вывод МОЛ--------------------//
            Podpisanty MOL = kom.FirstOrDefault(h => h.Nazn.Trim() == "МОЛ");

            if (MOL == null)
            {
                MOLFIO = "";
            }
            else
            {
                MOLFIO = MOL.FIO.Trim().ToString();
            }

            List<InventoryM> invent = new List<InventoryM>();
            invent = db.InventoryM.Where(t => t.LocID == locat & t.DateInv == datInv).OrderBy(g=>g.tanks.inventory_NUM).ToList();
            MemoryStream workStream = new MemoryStream();


            // Имя создаваемого файла. 
            string strPDFFileName = string.Format("Report.pdf");
            Document doc = new Document();
            doc.SetPageSize(PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, workStream);
            writer.CloseStream = false;
                        
            //--------------------------------------------------------------------

            // Подключение русскоязычного шрифта.
            string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font f08 = new Font(baseFont, 8);
            Font f12 = new Font(baseFont, 12);
            Font f14 = new Font(baseFont, 14);
            Font f16 = new Font(baseFont, 16);
            Font f12Bold = new Font(baseFont, 12, Font.BOLD);
            Font f18Bold = new Font(baseFont, 18, Font.BOLD);
            Font f20Bold = new Font(baseFont, 20, Font.BOLD);

            // Открытие документа.
            doc.Open();

            // Создание элементов.
            Paragraph par1 = new Paragraph("Форма утверждена", f08);
            Paragraph par2 = new Paragraph("Положением по бухгалтерскому учету", f08);
            Paragraph par3 = new Paragraph("Учетная политика ОАО Гомельтранснефть Дружба", f08);
            Paragraph par4 = new Paragraph("АКТ", f12Bold);
            Paragraph par5 = new Paragraph("Инвентаризация нефти в технологических емкостях филиала " +  Filstr, f12Bold);
            Paragraph par6 = new Paragraph("на 24:00 часа Московского времени " + formatdat.ToString("d") + " года", f12Bold);
            Paragraph par7 = new Paragraph("Председатель комиссии - " + PredDolj + " " + PredFIO, f12);
            Paragraph par8 = new Paragraph("Члены комиссии:", f12Bold);
            par1.Alignment = Element.ALIGN_RIGHT;
            par2.Alignment = Element.ALIGN_RIGHT;
            par3.Alignment = Element.ALIGN_RIGHT;
            par4.Alignment = Element.ALIGN_CENTER;
            par5.Alignment = Element.ALIGN_CENTER;
            par6.Alignment = Element.ALIGN_CENTER;
            par7.Alignment = Element.ALIGN_LEFT;
            par8.Alignment = Element.ALIGN_LEFT;


            PdfPTable tableKom = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell();
            tableKom.WidthPercentage = 30f;
            tableKom.HorizontalAlignment = Element.ALIGN_LEFT;



            foreach (var item in kom.Where(h => h.Nazn.Trim() == "Член комиссии"))
            {
                cell1 = new PdfPCell(new Phrase(item.Doljnost.Trim() + " " + item.FIO.Trim(), f12));
                cell1.BorderColor = BaseColor.WHITE;
                tableKom.AddCell(cell1);
            }

            PdfPTable tableTank = new PdfPTable(9);
            PdfPCell cell2 = new PdfPCell();
            tableTank.WidthPercentage = 100f;
            float[] columnWidths = new float[] { 3f, 27f, 10f, 10f, 10f, 10, 10f, 10f, 10f };
            tableTank.SetWidths(columnWidths);

            //--------------------Шапка таблицы -------------------------------//
            cell2 = new PdfPCell(new Phrase("№", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Наименование, тип резервуара, место установки", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Общий уровень нефти, мм", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Уровень подтоварной воды, мм", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Общий объем, м", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Объем подтоварной воды, м", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Объем нефти, м", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Rowspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("В том числе минимально допустимые остатки в резервуарах, м", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Colspan = 2;
            tableTank.AddCell(cell2);
            //----------------вторая строка-----------------------------------------------//
            cell2 = new PdfPCell(new Phrase("Уровень, мм", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("Объем, м", f08));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            tableTank.AddCell(cell2);

            //------------------Конец шапки таблицы ---------------------------------------//
            int p = 0;
            decimal VITOG = 0.0M;
            foreach (var tan in invent)
            {
                p++;
                cell2 = new PdfPCell(new Phrase(p.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase((tan.tanks.tank_NAME +"; "+ tan.tanks.point).ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.Uroven.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.UrovH2O.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase((tan.VH2O + tan.V20).ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.VH2O.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.V20.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.tanks.tech_min_mm.ToString(), f12));
                tableTank.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(tan.tanks.techMinV.ToString(), f12));
                tableTank.AddCell(cell2);
                VITOG = (decimal)(VITOG + tan.VH2O + tan.V20);
            }
            //---------Итоги------------//
            cell2 = new PdfPCell(new Phrase("ИТОГО:", f12));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.Colspan = 2;
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase(VITOG.ToString(), f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            cell2 = new PdfPCell(new Phrase("", f12));
            tableTank.AddCell(cell2);

            //-------------Конец таблицы----------------//

            Paragraph par9 = new Paragraph("Объем нефти по филиалу: " + "     " + VITOG.ToString(), f12);

            //---------------Подписанты-----------------//

            PdfPTable tabKom = new PdfPTable(2);
            PdfPCell cell3 = new PdfPCell();
            tabKom.WidthPercentage = 90f;
            tabKom.HorizontalAlignment = Element.ALIGN_LEFT;
            float[] columnWidths1 = new float[] { 45f, 45f };
            tabKom.SetWidths(columnWidths1);

            cell3 = new PdfPCell(new Phrase("Председатель комиссии________________" + PredFIO, f12));
            cell3.BorderColor = BaseColor.WHITE;
            tabKom.AddCell(cell3);

            cell3 = new PdfPCell(new Phrase("Члены комиссии:", f12));
            cell3.BorderColor = BaseColor.WHITE;
            tabKom.AddCell(cell3);

            foreach (var item in kom.Where(h => h.Nazn.Trim() == "Член комиссии"))
            {
                cell3 = new PdfPCell(new Phrase("", f12));
                cell3.BorderColor = BaseColor.WHITE;
                tabKom.AddCell(cell3);

                cell3 = new PdfPCell(new Phrase("_____________" + item.FIO.Trim(), f12));
                cell3.BorderColor = BaseColor.WHITE;
                tabKom.AddCell(cell3);
            }
            //------------Конец таблицы с подписантами-------------//

            Paragraph par10 = new Paragraph("Материально ответственное лицо_____________" + MOLFIO, f12);

            // Добавление элементов в документ.
            doc.Add(par1);
            doc.Add(par2);
            doc.Add(par3);
            doc.Add(par4);
            doc.Add(par5);
            doc.Add(par6);
            doc.Add(par7);
            doc.Add(par8);
            doc.Add(tableKom);
            doc.Add(new Paragraph(" ", f08));
            doc.Add(tableTank);
            doc.Add(par9);
            doc.Add(new Paragraph(" ", f08));
            doc.Add(tabKom);
            doc.Add(par10);

            // Закрытие документа.  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);
        }

        // Редактирование Инвенторизации//

        public ActionResult InventoryEdit(int ID)
        {
            InventoryM inven = new InventoryM();
            inven = db.InventoryM.FirstOrDefault(a => a.ID == ID);
            return PartialView(inven);
        }
        //-------------------------------//

        //Сохранение редактирования инвенторизации------------//
        [HttpPost]
        public ActionResult InventoryEditSave(int ID, string UserDC, string Uroven, string V20, string UrovH2O, string VH2O)
        {
            try
            {
                InventoryM inv = new InventoryM();
                inv = db.InventoryM.FirstOrDefault(s => s.ID == ID);

                inv.UserDC = UserDC.Trim();
                inv.Uroven = Convert.ToDecimal(Uroven);
                inv.V20 = Convert.ToDecimal(V20);
                //inv.Temper = Convert.ToDecimal(Temper);
                //inv.Vol = Convert.ToDecimal(Vol);
                //inv.Plotnost = Convert.ToDecimal(Plotnost);
                //inv.Massa = Convert.ToDecimal(Massa);
                inv.UrovH2O = Convert.ToDecimal(UrovH2O);
                inv.VH2O = Convert.ToDecimal(VH2O);
                db.SaveChanges();

                ViewBag.Message = "Инвенторизация успешно изменена";

            }
            catch (Exception e)
            {
                ViewBag.Message = "Ошибка. Текст ошибки: " + e.ToString();
            }

            return PartialView();
        }
        //-----------------------------//
        //-------------------Вывод инвенторизации Гомеля в зависимости от выбранной даты-------

        public ActionResult GetInventoryGomel(DateTime datapicker)
        {
            List<InventoryM> GetInventorGomel = new List<InventoryM>();
            GetInventorGomel = db.InventoryM.Where(j => j.LocID == 1 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventGomel = GetInventorGomel;

            return PartialView(GetInventorGomel);
        }

        //-------------------Вывод инвенторизации Защебье в зависимости от выбранной даты-------

        public ActionResult GetInventoryZasch(DateTime datapicker)
        {
            List<InventoryM> GetInventorZasch = new List<InventoryM>();
            GetInventorZasch = db.InventoryM.Where(j => j.LocID == 2 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventZasch = GetInventorZasch;

            return PartialView(GetInventorZasch);
        }

        //-------------------Вывод инвенторизации Мозыря в зависимости от выбранной даты-------

        public ActionResult GetInventoryMozyr(DateTime datapicker)
        {
            List<InventoryM> GetInventorMozyr = new List<InventoryM>();
            GetInventorMozyr = db.InventoryM.Where(j => j.LocID == 4 & j.DateInv == datapicker).OrderBy(h => h.tanks.inventory_NUM).ToList();

            ViewBag.inventMozyr = GetInventorMozyr;

            return PartialView(GetInventorMozyr);
        }

        //-------------------Вывод инвенторизации Кобрина в зависимости от выбранной даты-------

        public ActionResult GetInventoryKobrin(DateTime datapicker)
        {
            List<InventoryM> GetInventorKobrin = new List<InventoryM>();
            GetInventorKobrin = db.InventoryM.Where(j => j.LocID == 3 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventKobrin = GetInventorKobrin;

            return PartialView(GetInventorKobrin);
        }

        //-------------------Вывод инвенторизации Турова в зависимости от выбранной даты-------

        public ActionResult GetInventoryTurov(DateTime datapicker)
        {
            List<InventoryM> GetInventorTurov = new List<InventoryM>();
            GetInventorTurov = db.InventoryM.Where(j => j.LocID == 7 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventTurov = GetInventorTurov;

            return PartialView(GetInventorTurov);
        }

        //-------------------Вывод инвенторизации Пинска в зависимости от выбранной даты-------

        public ActionResult GetInventoryPinsk(DateTime datapicker)
        {
            List<InventoryM> GetInventorPinsk = new List<InventoryM>();
            GetInventorPinsk = db.InventoryM.Where(j => j.LocID == 6 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventPinsk = GetInventorPinsk;

            return PartialView(GetInventorPinsk);
        }

        //-------------------Вывод инвенторизации Новополоцка в зависимости от выбранной даты-------

        public ActionResult GetInventoryNovop(DateTime datapicker)
        {
            List<InventoryM> GetInventorNovop = new List<InventoryM>();
            GetInventorNovop = db.InventoryM.Where(j => j.LocID == 5 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventNovop = GetInventorNovop;

            return PartialView(GetInventorNovop);
        }

        //-------------------Вывод инвенторизации Горки в зависимости от выбранной даты-------

        public ActionResult GetInventoryGorki(DateTime datapicker)
        {
            List<InventoryM> GetInventorGorki = new List<InventoryM>();
            GetInventorGorki = db.InventoryM.Where(j => j.LocID == 9 & j.DateInv == datapicker).OrderBy(h => h.IDRez).ToList();

            ViewBag.inventGorki = GetInventorGorki;

            return PartialView(GetInventorGorki);
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Гомель-------
        public ActionResult GetUrovGomel(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 
            List<tanks> gomel = new List<tanks>();
            gomel = db.tanks.Where(j => j.location_ID == 1).ToList();
            ViewBag.gomel = gomel;

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();



            if (resName == "GomelNS1.Level.TankLeak400.1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 1) == null || calibrationList.FirstOrDefault(j => j.tankid == 1) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }


            else
            if (resName == "GomelNS2.Level.TankLeak400.2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 2) == null || calibrationList.FirstOrDefault(j => j.tankid == 2) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "GomelNS1.Level.TankLeak100.1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 3) == null || calibrationList.FirstOrDefault(j => j.tankid == 3) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "GomelNS1.Level.TankLeak100.2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 4) == null || calibrationList.FirstOrDefault(j => j.tankid == 4) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "GomelScr.Level.TankLeak30")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 6) == null || calibrationList.FirstOrDefault(j => j.tankid == 6) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "GomelNS1.Level.TankLeak12")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 7) == null || calibrationList.FirstOrDefault(j => j.tankid == 7) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "GomelNS2.Level.TankLeak40_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 8) == null || calibrationList.FirstOrDefault(j => j.tankid == 8) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "GomelNS2.Level.TankLeak40_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 9) == null || calibrationList.FirstOrDefault(j => j.tankid == 9) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            {
                V = 0;
            }

            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Защебье-------
        public ActionResult GetUrovZasch(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 
            List<tanks> zaschebe = new List<tanks>();
            zaschebe = db.tanks.Where(j => j.location_ID == 2).ToList();
            ViewBag.zaschebe = zaschebe;

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();


            if (resName == "ZaschNS1.Level.TankLeak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 10) == null || calibrationList.FirstOrDefault(j => j.tankid == 10) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "ZaschNS2.Level.Tank200_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 11) == null || calibrationList.FirstOrDefault(j => j.tankid == 11) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "ZaschNS2.Level.Tank200_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 12) == null || calibrationList.FirstOrDefault(j => j.tankid == 12) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "ZaschNS2.Level.Tank100_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 13) == null || calibrationList.FirstOrDefault(j => j.tankid == 13) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "ZaschNS2.Level.Tank100_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 14) == null || calibrationList.FirstOrDefault(j => j.tankid == 14) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "ZaschNS2.Level.Tank100_3")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 15) == null || calibrationList.FirstOrDefault(j => j.tankid == 15) == null)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            {
                V = 0;
            }



            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды Мозырь-------
        public ActionResult GetUrovMozyr(string ID, string Urov, string resName)
        {
            List<tanks> mozyr = new List<tanks>();
            mozyr = db.tanks.Where(j => j.location_ID == 4).OrderBy(g=>g.inventory_NUM).ToList();
            ViewBag.mozyr = mozyr;

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();


            if (resName == "SIKN461.Level.TankLeak")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 44) == null || calibrationList.FirstOrDefault(j => j.tankid == 44) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "MozyrBK1.Level.TankLeak25_Scr4")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 47) == null || calibrationList.FirstOrDefault(j => j.tankid == 47) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "MozyrNS5.Level.TankLeak461_1")
            {
                if (Convert.ToDouble(Urov) == 0 || calibrationList.LastOrDefault(g => g.tankid == 26) == null || calibrationList.FirstOrDefault(j => j.tankid == 26) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "MozyrNS5.Level.TankLeak461_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 27) == null || calibrationList.FirstOrDefault(j => j.tankid == 27) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "MozyrNS41.Level.TankLeak63")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 21) == null || calibrationList.FirstOrDefault(j => j.tankid == 21) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "MozyrNS3.Level.TankLeak47")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 38) == null || calibrationList.FirstOrDefault(j => j.tankid == 38) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "MozyrNS5.Level.TankLeak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 39) == null || calibrationList.FirstOrDefault(j => j.tankid == 39) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "MozyrNS2.Level.TanlLeak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 24) == null || calibrationList.FirstOrDefault(j => j.tankid == 24) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "Moz40")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 40) == null || calibrationList.FirstOrDefault(j => j.tankid == 40) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 40 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 40 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 40 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 40 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 40 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 40 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "Moz48")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 48) == null || calibrationList.FirstOrDefault(j => j.tankid == 48) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 48 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 48 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 48 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 48 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 48 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 48 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "Moz49")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 49) == null || calibrationList.FirstOrDefault(j => j.tankid == 49) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 49 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 49 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 49 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 49 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 49 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 49 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "MozyrBK18.Tank.Level.19")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 45) == null || calibrationList.FirstOrDefault(j => j.tankid == 45) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "MozyrBK18.Tank.Level.20")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 46) == null || calibrationList.FirstOrDefault(j => j.tankid == 46) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }


            else
            {
                V = 0;
            }


            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Туров-------
        public ActionResult GetUrovTurov(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();


            if (resName == "TurovNS2.Level.TankLeak200_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 33) == null || calibrationList.FirstOrDefault(j => j.tankid == 33) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }

            }
            else
            if (resName == "TurovNS2.Level.TankLeak200_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 34) == null || calibrationList.FirstOrDefault(j => j.tankid == 34) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "TurovNS2.Level.TankLeak25_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 65) == null || calibrationList.FirstOrDefault(j => j.tankid == 65) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "TurovNS2.Level.TankLeak25_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 66) == null || calibrationList.FirstOrDefault(j => j.tankid == 66) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "TurovNS1.Level.TankLeak12")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 37) == null || calibrationList.FirstOrDefault(j => j.tankid == 37) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            {
                V = 0;
            }

            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Пинск-------
        public ActionResult GetUrovPinsk(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            if (resName == "PinskNS2.Level.TankLeak200_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 28) == null || calibrationList.FirstOrDefault(j => j.tankid == 28) == null || Convert.ToDouble(Urov) <= 0.00000001)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "PinskNS2.Level.TankLeak200_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 29) == null || calibrationList.FirstOrDefault(j => j.tankid == 29) == null || Convert.ToDouble(Urov) <= 0.00000001)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "PinskNS2.Level.TankLeak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 30) == null || calibrationList.FirstOrDefault(j => j.tankid == 30) == null || Convert.ToDouble(Urov) <= 0.00000001)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "PinskScr.Level.TankLeak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 31) == null || calibrationList.FirstOrDefault(j => j.tankid == 31) == null || Convert.ToDouble(Urov) <= 0.00000001)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "PinskNS1.Level.TankLeak40")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 32) == null || calibrationList.FirstOrDefault(j => j.tankid == 32) == null || Convert.ToDouble(Urov) <= 0.00000001)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            {
                V = 0;
            }

            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Кобрин-------
        public ActionResult GetUrovKobrin(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();


            if (resName == "KobrinNS2.Level.TankLeak200_1")
            {

                if (calibrationList.LastOrDefault(g => g.tankid == 16) == null || calibrationList.FirstOrDefault(j => j.tankid == 16) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "KobrinNS2.Level.TankLeak200_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 17) == null || calibrationList.FirstOrDefault(j => j.tankid == 17) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "KobrinNS2.Level.TankLeak100_1")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 18) == null || calibrationList.FirstOrDefault(j => j.tankid == 18) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "KobrinNS2.Level.TankLeak100_2")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 19) == null || calibrationList.FirstOrDefault(j => j.tankid == 19) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }
            else
            if (resName == "KobrinNS1.Level.TankLeak12")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 20) == null || calibrationList.FirstOrDefault(j => j.tankid == 20) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            if (resName == "MozAdam.km441.Level.Leak25")
            {
                if (calibrationList.LastOrDefault(g => g.tankid == 60) == null || calibrationList.FirstOrDefault(j => j.tankid == 60) == null || Convert.ToDouble(Urov) == 0)
                {
                    V = 0;
                }
                else
                {
                    if (calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                    Upercent = (Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                    V = VMin + (VMax - VMin) * Upercent;
                }
            }

            else
            {
                V = 0;
            }

            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды НПС Новополоцк-------
        public ActionResult GetUrovNovop(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 
            List<tanks> gomel = new List<tanks>();
            gomel = db.tanks.Where(j => j.location_ID == 1).ToList();
            ViewBag.gomel = gomel;


            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            V = 0;


            ViewBag.ID = V;

            return PartialView();
        }

        //-------------------Отслеживание изменения уровня подтоварной воды Горки-------
        public ActionResult GetUrovGorki(string ID, string Urov, string resName)
        {
            //---------------------------------------------------------------------------- 

            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            
                if (resName == "GorkiNS2.Level.TankLeak25_1")
                {
                if (calibrationList.LastOrDefault(g => g.tankid == 58) == null || calibrationList.FirstOrDefault(j => j.tankid == 58) == null || Convert.ToDouble(Urov) == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                    if (calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                        Upercent = ((double)Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (resName == "GorkiNS2.Level.TankLeak25_2")
                {
                    
                    if (calibrationList.LastOrDefault(g => g.tankid == 59) == null || calibrationList.FirstOrDefault(j => j.tankid == 59) == null || Convert.ToDouble(Urov) == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                    if (calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        UMin = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= Convert.ToDouble(Urov)).oillevel;
                    }
                    UMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > Convert.ToDouble(Urov)).oillevel;
                    if (calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= Convert.ToDouble(Urov)) == null)
                    {
                        VMin = 0;
                    }
                    else
                    {
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= Convert.ToDouble(Urov)).oilvolume;
                    }
                    VMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > Convert.ToDouble(Urov)).oilvolume;
                        Upercent = ((double)Convert.ToDouble(Urov) - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    V = 0;
                }



                ViewBag.ID = V;

                return PartialView();
            }

        //-------Получение данных объема в зависимости от введенной даты--------------
        public ActionResult GetDBGomel(DateTime datapicker)
        {
            List<tanks> gomel = new List<tanks>();
            gomel = db.tanks.Where(j => j.location_ID == 1).ToList();
            ViewBag.gomel = gomel;

            GomelNS1_Level_TankLeak400_1 GomelUr1 = new GomelNS1_Level_TankLeak400_1();
            //GomelUr1 = db2.GomelNS1_Level_TankLeak400_1.OrderByDescending(a => a.dt).FirstOrDefault();
            GomelUr1 = db2.GomelNS1_Level_TankLeak400_1.Where(a => a.dt >= datapicker).OrderBy(a=>a.dt).FirstOrDefault();
            ViewBag.GomelUr1 = GomelUr1.value;

            GomelNS2_Level_TankLeak400_2 GomelUr2 = new GomelNS2_Level_TankLeak400_2();
            GomelUr2 = db2.GomelNS2_Level_TankLeak400_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr2 = GomelUr2.value;

            GomelNS1_Level_TankLeak100_1 GomelUr3 = new GomelNS1_Level_TankLeak100_1();
            GomelUr3 = db2.GomelNS1_Level_TankLeak100_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr3 = GomelUr3.value;

            GomelNS1_Level_TankLeak100_2 GomelUr4 = new GomelNS1_Level_TankLeak100_2();
            GomelUr4 = db2.GomelNS1_Level_TankLeak100_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr4 = GomelUr4.value;

            GomelScr_Level_TankLeak30 GomelUr5 = new GomelScr_Level_TankLeak30();
            GomelUr5 = db2.GomelScr_Level_TankLeak30.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr5 = GomelUr5.value;

            GomelNS1_Level_TankLeak12 GomelUr6 = new GomelNS1_Level_TankLeak12();
            GomelUr6 = db2.GomelNS1_Level_TankLeak12.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr6 = GomelUr6.value;

            GomelNS2_Level_TankLeak40_1 GomelUr7 = new GomelNS2_Level_TankLeak40_1();
            GomelUr7 = db2.GomelNS2_Level_TankLeak40_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr7 = GomelUr7.value;

            GomelNS2_Level_TankLeak40_2 GomelUr8 = new GomelNS2_Level_TankLeak40_2();
            GomelUr8 = db2.GomelNS2_Level_TankLeak40_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr8 = GomelUr8.value;

            GomelNS1_Level_TankLeak20 GomelUr9 = new GomelNS1_Level_TankLeak20();
            GomelUr9 = db2.GomelNS1_Level_TankLeak20.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GomelUr9 = GomelUr9.value;

            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TGom = new TablesS();
            List<TablesS> TabGomel = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in gomel)
            {

                if (item.opc_TAG == "GomelNS1.Level.TankLeak400.1")
                {
                    UROV = GomelUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 1 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 1) == null || calibrationList.FirstOrDefault(j => j.tankid == 1) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 1 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 1 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }


                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak400.2")
                {
                    UROV = GomelUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 2 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 2) == null || calibrationList.FirstOrDefault(j => j.tankid == 2) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 2 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 2 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak100.1")
                {
                    UROV = GomelUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 3 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 3) == null || calibrationList.FirstOrDefault(j => j.tankid == 3) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 3 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 3 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak100.2")
                {

                    UROV = GomelUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 4 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 4) == null || calibrationList.FirstOrDefault(j => j.tankid == 4) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 4 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 4 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelScr.Level.TankLeak30")
                {
                    UROV = GomelUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 6 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 6) == null || calibrationList.FirstOrDefault(j => j.tankid == 6) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 6 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 6 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak12")
                {
                    UROV = GomelUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 7 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 7) == null || calibrationList.FirstOrDefault(j => j.tankid == 7) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 7 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 7 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak40_1")
                {
                    UROV = GomelUr7.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 8 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 8) == null || calibrationList.FirstOrDefault(j => j.tankid == 8) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 8 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 8 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelNS2.Level.TankLeak40_2")
                {
                    UROV = GomelUr8.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 9 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 9) == null || calibrationList.FirstOrDefault(j => j.tankid == 9) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 9 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 9 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "GomelNS1.Level.TankLeak20")
                {
                    UROV = GomelUr9.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 62 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 62) == null || calibrationList.FirstOrDefault(j => j.tankid == 5) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 62 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 62 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 62 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 62 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabGomel.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabGomel = TabGomel;

            return PartialView(TabGomel);

        }
        //-----------------------Защебье-----------------------------------------------------
        public ActionResult GetDBZasch(DateTime datapicker)
        {
            List<tanks> zaschebe = new List<tanks>();
            zaschebe = db.tanks.Where(j => j.location_ID == 2).ToList();
            ViewBag.zaschebe = zaschebe;

            ZaschNS1_Level_TankLeak25 ZaschUr1 = new ZaschNS1_Level_TankLeak25();
            ZaschUr1 = db2.ZaschNS1_Level_TankLeak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr1 = ZaschUr1.value;

            ZaschNS2_Level_TankLeak200_1 ZaschUr2 = new ZaschNS2_Level_TankLeak200_1();
            ZaschUr2 = db2.ZaschNS2_Level_TankLeak200_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr2 = ZaschUr2.value;

            ZaschNS2_Level_TankLeak200_2 ZaschUr3 = new ZaschNS2_Level_TankLeak200_2();
            ZaschUr3 = db2.ZaschNS2_Level_TankLeak200_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr3 = ZaschUr3.value;

            ZaschNS2_Level_TankLeak100_1 ZaschUr4 = new ZaschNS2_Level_TankLeak100_1();
            ZaschUr4 = db2.ZaschNS2_Level_TankLeak100_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr4 = ZaschUr4.value;

            ZaschNS2_Level_TankLeak100_2 ZaschUr5 = new ZaschNS2_Level_TankLeak100_2();
            ZaschUr5 = db2.ZaschNS2_Level_TankLeak100_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr5 = ZaschUr5.value;

            ZaschNS2_Level_TankLeak100_3 ZaschUr6 = new ZaschNS2_Level_TankLeak100_3();
            ZaschUr6 = db2.ZaschNS2_Level_TankLeak100_3.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.ZaschUr6 = ZaschUr6.value;
                        
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TZasch = new TablesS();
            List<TablesS> TabZasch = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in zaschebe)
            {
                if (item.opc_TAG == "ZaschNS1.Level.TankLeak25")
                {
                    UROV = ZaschUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 10 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 10) == null || calibrationList.FirstOrDefault(j => j.tankid == 10) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 10 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 10 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank200_1")
                {
                    UROV = ZaschUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 11 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 11) == null || calibrationList.FirstOrDefault(j => j.tankid == 11) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 11 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 11 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank200_2")
                {
                    UROV = ZaschUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 12 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 12) == null || calibrationList.FirstOrDefault(j => j.tankid == 12) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 12 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 12 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_1")
                {
                    UROV = ZaschUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 13 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 13) == null || calibrationList.FirstOrDefault(j => j.tankid == 13) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 13 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 13 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_2")
                {
                    UROV = ZaschUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 14 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 14) == null || calibrationList.FirstOrDefault(j => j.tankid == 14) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 14 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 14 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "ZaschNS2.Level.Tank100_3")
                {
                    UROV = ZaschUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 15 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 15) == null || calibrationList.FirstOrDefault(j => j.tankid == 15) == null)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 15 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 15 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabZasch.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabZasch = TabZasch;

            return PartialView(zaschebe);
        }

          //-------------Мозырь----------------------------------------------
        public ActionResult GetDBMozyr(DateTime datapicker)
        {
            List<tanks> mozyr = new List<tanks>();
            mozyr = db.tanks.Where(j => j.location_ID == 4).OrderBy(g => g.inventory_NUM).ToList();
            ViewBag.mozyr = mozyr;

            SIKN461_Level_TankLeak MozUr1 = new SIKN461_Level_TankLeak();
            MozUr1 = db2.SIKN461_Level_TankLeak.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr1 = MozUr1.value;

            MozyrBK1_Level_TankLeak25_Scr4 MozUr2 = new MozyrBK1_Level_TankLeak25_Scr4();
            MozUr2 = db2.MozyrBK1_Level_TankLeak25_Scr4.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr2 = MozUr2.value;

            MozyrNS5_Level_TankLeak461_1 MozUr3 = new MozyrNS5_Level_TankLeak461_1();
            MozUr3 = db2.MozyrNS5_Level_TankLeak461_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr3 = MozUr3.value;

            MozyrNS2_Level_TanlLeak1_2 MozUr4 = new MozyrNS2_Level_TanlLeak1_2();
            MozUr4 = db2.MozyrNS2_Level_TanlLeak1_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr4 = MozUr4.value;

            MozyrNS41_Level_TankLeak63 MozUr5 = new MozyrNS41_Level_TankLeak63();
            MozUr5 = db2.MozyrNS41_Level_TankLeak63.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr5 = MozUr5.value;

            MozyrNS3_Level_TankLeak47 MozUr6 = new MozyrNS3_Level_TankLeak47();
            MozUr6 = db2.MozyrNS3_Level_TankLeak47.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.MozUr6 = MozUr6.value;

            MozyrNS2_Level_TanlLeak25 MozUr7 = new MozyrNS2_Level_TanlLeak25();
            MozUr7 = db2.MozyrNS2_Level_TanlLeak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.Moz7 = MozUr7.value;

            MozyrNS5_Level_TankLeak25 MozUr8 = new MozyrNS5_Level_TankLeak25();
            MozUr8 = db2.MozyrNS5_Level_TankLeak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.Moz8 = MozUr8.value;

            MozyrBK18_Tank_Level_19 MozUr9 = new MozyrBK18_Tank_Level_19();
            MozUr9 = db2.MozyrBK18_Tank_Level_19.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz9 = MozUr9.value;

            MozyrBK18_Tank_Level_20 MozUr10 = new MozyrBK18_Tank_Level_20();
            MozUr10 = db2.MozyrBK18_Tank_Level_20.OrderByDescending(a => a.dt).FirstOrDefault();
            ViewBag.Moz10 = MozUr10.value;
            

            //-----------------------------------------Вывод данных правильный Мозырь---------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TMoz = new TablesS();
            List<TablesS> TabMozyr = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in mozyr)
            {
                if (item.opc_TAG == "SIKN461.Level.TankLeak")
                {
                    UROV = MozUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 44 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 44) == null || calibrationList.FirstOrDefault(j => j.tankid == 44) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 44 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 44 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrBK1.Level.TankLeak25_Scr4")
                {
                    UROV = MozUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 47 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 47) == null || calibrationList.FirstOrDefault(j => j.tankid == 47) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 47 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 47 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak461_1")
                {
                    UROV = MozUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 26 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (UROV == 0 || calibrationList.LastOrDefault(g => g.tankid == 26) == null || calibrationList.FirstOrDefault(j => j.tankid == 26) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 26 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 26 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak461_2")
                {
                    UROV = MozUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 27 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 27) == null || calibrationList.FirstOrDefault(j => j.tankid == 27) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 27 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 27 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS41.Level.TankLeak63")
                {
                    UROV = MozUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 21 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 21) == null || calibrationList.FirstOrDefault(j => j.tankid == 21) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 21 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 21 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "MozyrNS3.Level.TankLeak47")
                {
                    UROV = MozUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 38 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 38) == null || calibrationList.FirstOrDefault(j => j.tankid == 38) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 38 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 38 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrNS5.Level.TankLeak25")
                {
                    UROV = MozUr8.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 39 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 39) == null || calibrationList.FirstOrDefault(j => j.tankid == 39) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 39 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 39 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrNS2.Level.TanlLeak25")
                {
                    UROV = MozUr7.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 24 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 24) == null || calibrationList.FirstOrDefault(j => j.tankid == 24) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 24 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 24 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrBK18.Tank.Level.19")
                {
                    UROV = MozUr9.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 45 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 45) == null || calibrationList.FirstOrDefault(j => j.tankid == 45) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 45 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 45 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozyrBK18.Tank.Level.20")
                {
                    UROV = MozUr10.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 46 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 46) == null || calibrationList.FirstOrDefault(j => j.tankid == 46) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 46 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 46 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }



                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabMozyr.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    point = item.point,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabMozyr = TabMozyr;
            //-----------------------------------------------------------------------------------------------------------

            return PartialView(mozyr);        
    }

        //-------Туров----------------------------------------------------------------
        public ActionResult GetDBTurov(DateTime datapicker)
        {
            List<tanks> turov = new List<tanks>();
            turov = db.tanks.Where(j => j.location_ID == 7).ToList();
            ViewBag.turov = turov;

            TurovNS2_Level_TankLeak200_1 TurUr1 = new TurovNS2_Level_TankLeak200_1();
            TurUr1 = db2.TurovNS2_Level_TankLeak200_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.TurUr1 = TurUr1.value;

            TurovNS2_Level_TankLeak200_2 TurUr2 = new TurovNS2_Level_TankLeak200_2();
            TurUr2 = db2.TurovNS2_Level_TankLeak200_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.TurUr2 = TurUr2.value;

            TurovNS2_Level_TankLeak25_1 TurUr3 = new TurovNS2_Level_TankLeak25_1();
            TurUr3 = db2.TurovNS2_Level_TankLeak25_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.TurUr3 = TurUr3.value;

            TurovNS2_Level_TankLeak25_2 TurUr4 = new TurovNS2_Level_TankLeak25_2();
            TurUr4 = db2.TurovNS2_Level_TankLeak25_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.TurUr4 = TurUr4.value;

            TurovNS1_Level_TankLeak12 TurUr5 = new TurovNS1_Level_TankLeak12();
            TurUr5 = db2.TurovNS1_Level_TankLeak12.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.TurUr5 = TurUr5.value;

            double? UROV = null;
            calibration VH2Calib = new calibration();
            double? VH2 = null;
            TablesS TTurov = new TablesS();
            List<TablesS> TabTurov = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in turov)
            {
                if (item.opc_TAG == "TurovNS2.Level.TankLeak200_1")
                {
                    UROV = TurUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 33 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 33) == null || calibrationList.FirstOrDefault(j => j.tankid == 33) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 33 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 33 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }

                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak200_2")
                {
                    UROV = TurUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 34 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 34) == null || calibrationList.FirstOrDefault(j => j.tankid == 34) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 34 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 34 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak25_1")
                {
                    UROV = TurUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 65 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 65) == null || calibrationList.FirstOrDefault(j => j.tankid == 65) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 65 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 65 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS2.Level.TankLeak25_2")
                {
                    UROV = TurUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 66 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 66) == null || calibrationList.FirstOrDefault(j => j.tankid == 66) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 66 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 66 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "TurovNS1.Level.TankLeak12")
                {
                    UROV = TurUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 37 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 37) == null || calibrationList.FirstOrDefault(j => j.tankid == 37) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 37 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 37 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabTurov.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabTurov = TabTurov;

            return PartialView(turov);
        }

        //----------------Пинск------------------------------------------------------------
        public ActionResult GetDBPinsk(DateTime datapicker)
        {
            List<tanks> pinsk = new List<tanks>();
            pinsk = db.tanks.Where(j => j.location_ID == 6).ToList();
            ViewBag.pinsk = pinsk;

            PinskNS2_Level_TankLeak200_1 PinUr1 = new PinskNS2_Level_TankLeak200_1();
            PinUr1 = db2.PinskNS2_Level_TankLeak200_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.PinUr1 = PinUr1.value;

            PinskNS2_Level_TankLeak200_2 PinUr2 = new PinskNS2_Level_TankLeak200_2();
            PinUr2 = db2.PinskNS2_Level_TankLeak200_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.PinUr2 = PinUr2.value;

            PinskNS2_Level_TankLeak25 PinUr3 = new PinskNS2_Level_TankLeak25();
            PinUr3 = db2.PinskNS2_Level_TankLeak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.PinUr3 = PinUr3.value;

            PinskScr_Level_TankLeak25 PinUr4 = new PinskScr_Level_TankLeak25();
            PinUr4 = db2.PinskScr_Level_TankLeak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.PinUr4 = PinUr4.value;

            PinskNS1_Level_TankLeak40 PinUr5 = new PinskNS1_Level_TankLeak40();
            PinUr5 = db2.PinskNS1_Level_TankLeak40.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.PinUr5 = PinUr5.value;

            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TPinsk = new TablesS();
            List<TablesS> TabPinsk = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in pinsk)
            {
                if (item.opc_TAG == "PinskNS2.Level.TankLeak200_1")
                {
                    UROV = PinUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 28 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 28) == null || calibrationList.FirstOrDefault(j => j.tankid == 28) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 28 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 28 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS2.Level.TankLeak200_2")
                {
                    UROV = PinUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 29 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 29) == null || calibrationList.FirstOrDefault(j => j.tankid == 29) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 29 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 29 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS2.Level.TankLeak25")
                {
                    UROV = PinUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 30 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }
                    if (calibrationList.LastOrDefault(g => g.tankid == 30) == null || calibrationList.FirstOrDefault(j => j.tankid == 30) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 30 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 30 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskScr.Level.TankLeak25")
                {
                    UROV = PinUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 31 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 31) == null || calibrationList.FirstOrDefault(j => j.tankid == 31) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 31 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 31 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "PinskNS1.Level.TankLeak40")
                {
                    UROV = PinUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 32 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 32) == null || calibrationList.FirstOrDefault(j => j.tankid == 32) == null || UROV <= 0.00000001)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 32 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 32 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabPinsk.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabPinsk = TabPinsk;

            return PartialView(pinsk);
        }

        //----------------Кобрин--------------------------------------------------------------------------------
        public ActionResult GetDBKobrin(DateTime datapicker)
        {
            List<tanks> kobrin = new List<tanks>();
            kobrin = db.tanks.Where(j => j.location_ID == 3).ToList();
            ViewBag.kobrin = kobrin;

            KobrinNS2_Level_TankLeak200_1 KobUr1 = new KobrinNS2_Level_TankLeak200_1();
            KobUr1 = db2.KobrinNS2_Level_TankLeak200_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr1 = KobUr1.value;

            KobrinNS2_Level_TankLeak200_2 KobUr2 = new KobrinNS2_Level_TankLeak200_2();
            KobUr2 = db2.KobrinNS2_Level_TankLeak200_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr2 = KobUr2.value;

            KobrinNS2_Level_TankLeak100_1 KobUr3 = new KobrinNS2_Level_TankLeak100_1();
            KobUr3 = db2.KobrinNS2_Level_TankLeak100_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr3 = KobUr3.value;

            KobrinNS2_Level_TankLeak100_2 KobUr4 = new KobrinNS2_Level_TankLeak100_2();
            KobUr4 = db2.KobrinNS2_Level_TankLeak100_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr4 = KobUr4.value;

            KobrinNS1_Level_TankLeak12 KobUr5 = new KobrinNS1_Level_TankLeak12();
            KobUr5 = db2.KobrinNS1_Level_TankLeak12.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr5 = KobUr5.value;

            MozAdam_km441_Level_Leak25 KobUr6 = new MozAdam_km441_Level_Leak25();
            KobUr6 = db2.MozAdam_km441_Level_Leak25.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.KobUr6 = KobUr6.value;
            //-----------------------------------------Вывод данных правильный Кобрин--------------------------------------------------------------------------------------
            double? UROV;
            calibration VH2Calib = new calibration();
            double? VH2 = VH2Calib.oilvolume;
            TablesS TKobrin = new TablesS();
            List<TablesS> TabKobrin = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in kobrin)
            {
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak200_1")
                {
                    UROV = KobUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 16 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 16) == null || calibrationList.FirstOrDefault(j => j.tankid == 16) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 16 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 16 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak200_2")
                {
                    UROV = KobUr2.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 17 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 17) == null || calibrationList.FirstOrDefault(j => j.tankid == 17) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 17 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 17 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak100_1")
                {
                    UROV = KobUr3.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 18 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 18) == null || calibrationList.FirstOrDefault(j => j.tankid == 18) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 18 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 18 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS2.Level.TankLeak100_2")
                {
                    UROV = KobUr4.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 19 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 19) == null || calibrationList.FirstOrDefault(j => j.tankid == 19) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 19 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 19 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "KobrinNS1.Level.TankLeak12")
                {
                    UROV = KobUr5.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 20 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 20) == null || calibrationList.FirstOrDefault(j => j.tankid == 20) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 20 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 20 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                if (item.opc_TAG == "MozAdam.km441.Level.Leak25")
                {
                    UROV = KobUr6.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 60 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 60) == null || calibrationList.FirstOrDefault(j => j.tankid == 60) == null || UROV == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= UROV).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > UROV).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 60 & g.oillevel <= UROV).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 60 & j.oillevel > UROV).oilvolume;
                        Upercent = (UROV - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabKobrin.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV

                });
            }
            ViewBag.TabKobrin = TabKobrin;

            return PartialView(kobrin);
        }
        //-------В Новополоцке нет уровнемеров---------------По крайней мере сейчас это не работает----------------------
        public ActionResult GetDBNovopolock(DateTime datapicker)
        {
            List<tanks> novopolock = new List<tanks>();
            novopolock = db.tanks.Where(j => j.location_ID == 5).ToList();
            ViewBag.novopolock = novopolock;

            return View(novopolock);
        }
        public ActionResult GetDBGorki(DateTime datapicker)
        {
            List<tanks> gorki = new List<tanks>();
            gorki = db.tanks.Where(j => j.location_ID == 9).ToList();
            ViewBag.gorki = gorki;

            GorkiNS2_Level_TankLeak25_1 GorkiUr1 = new GorkiNS2_Level_TankLeak25_1();
            GorkiUr1 = db2.GorkiNS2_Level_TankLeak25_1.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GorkiUr1 = GorkiUr1.value;

            GorkiNS2_Level_TankLeak25_2 GorkiUr2 = new GorkiNS2_Level_TankLeak25_2();
            GorkiUr2 = db2.GorkiNS2_Level_TankLeak25_2.Where(a => a.dt >= datapicker).OrderBy(a => a.dt).FirstOrDefault();
            ViewBag.GorkiUr2 = GorkiUr2.value;
                        
            double? UROV1 = null;

            calibration VH2Calib = new calibration();
            double? VH2 = null;
            TablesS TGorki = new TablesS();
            List<TablesS> TabGorki = new List<TablesS>();
            double UMin;
            double UMax;
            double VMin;
            double VMax;

            double? Upercent;
            double? V;
            List<calibration> calibrationList = new List<calibration>();
            calibrationList = db.calibration.OrderBy(f => f.tankid).ThenBy(h => h.oillevel).ToList();

            calibration VCalibr = new calibration();

            foreach (var item in gorki)
            {
                if (item.opc_TAG == "GorkiNS2.Level.TankLeak25_1")
                {

                    UROV1 = GorkiUr1.value;
                    VH2Calib = db.calibration.FirstOrDefault(a => a.tankid == 58 & a.oillevel == item.tech_min_mm);
                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }
                    if (calibrationList.LastOrDefault(g => g.tankid == 58) == null || calibrationList.FirstOrDefault(j => j.tankid == 58) == null || UROV1 == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= UROV1).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > UROV1).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 58 & g.oillevel <= UROV1).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 58 & j.oillevel > UROV1).oilvolume;
                        Upercent = ((double)UROV1 - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }
                else
                if (item.opc_TAG == "GorkiNS2.Level.TankLeak25_2")
                {
                    UROV1 = GorkiUr1.value;

                    if (VH2Calib == null)
                    {
                        VH2 = 0;
                    }
                    else
                    {
                        VH2 = VH2Calib.oilvolume;
                    }

                    if (calibrationList.LastOrDefault(g => g.tankid == 59) == null || calibrationList.FirstOrDefault(j => j.tankid == 59) == null || UROV1 == 0)
                    {
                        V = 0;
                    }
                    else
                    {
                        UMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= UROV1).oillevel;
                        UMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > UROV1).oillevel;
                        VMin = calibrationList.LastOrDefault(g => g.tankid == 59 & g.oillevel <= UROV1).oilvolume;
                        VMax = calibrationList.FirstOrDefault(j => j.tankid == 59 & j.oillevel > UROV1).oilvolume;
                        Upercent = ((double)UROV1 - UMin) / (UMax - UMin);
                        V = VMin + (VMax - VMin) * Upercent;
                    }
                }

                else
                {
                    UROV1 = 0;
                    VH2 = 0;
                    V = 0;
                }


                TabGorki.Add(new TablesS()
                {
                    LOCAT = item.location_ID,
                    tankID = item.tank_ID,
                    TANKNAME = item.tank_NAME,
                    OPCTAG = item.opc_TAG,
                    UROVEN = UROV1,
                    V20 = 0,
                    TEMPERAT = 0,
                    V = V,
                    PLOTNOST = 0,
                    MASSA = 0,
                    UROVENH2O = Convert.ToDouble(item.tech_min_mm),
                    VH2O = VH2,
                    minU = item.tech_min_mm,
                    minV = item.techMinV
                });
            }
            ViewBag.TabGorki = TabGorki;

            return PartialView(gorki);
        }



    }
}
