using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.BusinessLogic.WcfRemote
{
    public static class DataBaseDictionaries
    {
        private static Dictionary<decimal, int> tableIdAllTablesIndexDictionary;
        public static Dictionary<decimal, int> TableIdAllTablesIndexDictionary
        {
            get
            {
                if (tableIdAllTablesIndexDictionary == null)
                {
                    LoadTableIdAllTablesIndexDictionary();
                }
                return tableIdAllTablesIndexDictionary;
            }
        }
        public static Dictionary<string, List<DBItem>> MenuDictionary { get; set; }

        public static Dictionary<decimal, DBModifier> PizzaToppingsDictionary { get; set; }

        public static Dictionary<decimal, DBModifier> SaladToppingsDictionary { get; set; }

        public static Dictionary<decimal, DBTable> DbTablesDictionary { get; set; }

        private static Dictionary<ToppingName, decimal> toppingDbIdDictionary;
        public static Dictionary<ToppingName, decimal> ToppingDbIdDictionary
        {
            get
            {
                if (toppingDbIdDictionary == null)
                {
                    CreateToppingDbIdDictionary();
                }
                return toppingDbIdDictionary;
            }
        }

        private static Dictionary<decimal, ToppingName> dbIdToppingDictionary;
        public static Dictionary<decimal, ToppingName> DbIdToppingDictionary
        {
            get
            {
                if (dbIdToppingDictionary == null)
                {
                    CreateDbIdToppingDictionary();
                }
                return dbIdToppingDictionary;
            }
        }

        private static void CreateDbIdToppingDictionary()
        {
            dbIdToppingDictionary = new Dictionary<decimal, ToppingName>
            {
                 { 1, ToppingName.ExtraPSauceOS },
                {2, ToppingName.LightSauce },
                { 9, ToppingName.Lettuce },
                 { 11, ToppingName.ExtraCheese  },
                   { 12, ToppingName.Pepperoni },
                   { 13, ToppingName.GreenPeppers },
                { 14, ToppingName.Ham },
                   { 15, ToppingName.Feta },
                  { 16, ToppingName.ExtraPSauceOP },
                 { 17, ToppingName.Basil },
                {18, ToppingName.Major },
                  { 20, ToppingName.Meatballs  },
                   { 21, ToppingName.SundriedTomatoes },
                   { 23, ToppingName.BlackOlives },
                     { 24, ToppingName.Beef },
                     { 26, ToppingName.GreenOlives },
                                 { 27, ToppingName.Anchovies },
                                   { 28, ToppingName.Tomatoes },
                                 { 29, ToppingName.RoastedRedPepper },
                                  { 30, ToppingName.Steak },
                { 31, ToppingName.Artichokes },
                 { 32, ToppingName.BananaPeppers },
                   { 33, ToppingName.Zucchini },
                  { 34, ToppingName.Broccoli },
                    { 36, ToppingName.TempehOriginal },
                   { 37, ToppingName.TempehBBQ },
                   { 38, ToppingName.Jalapenos },
                    { 39, ToppingName.Pineapple },
                  { 40, ToppingName.Carrots },
                  { 41, ToppingName.Ricotta },
                    { 42, ToppingName.Spinach },
                { 43, ToppingName.Bacon },
                { 44, ToppingName.Onion },
                   { 47, ToppingName.Garlic },
                    { 48, ToppingName.RedOnions },
                       { 52, ToppingName.LightCook  },
                { 53, ToppingName.CrispyCook },
                 { 54, ToppingName.Cucumbers },
                  { 55, ToppingName.Seeds },
                    { 56, ToppingName.GarlicButterInsteadofPizzaSauce },
                     { 57, ToppingName.Almonds },
                      { 58, ToppingName.Apples },
                       { 59, ToppingName.Beef },
                       { 60, ToppingName.Cheese },
                { 61, ToppingName.DAIYA },
                 { 62, ToppingName.Teese },
                 { 64, ToppingName.DressingOnSide },
                   { 65, ToppingName.ExtraDressingOnSide },
                   { 66, ToppingName.Cheese },
                  { 67, ToppingName.PestoTopping },
                  { 68, ToppingName.WithOrder },
                  { 70, ToppingName.WithOrder },
                     { 75, ToppingName.ButterOk },
                   { 76, ToppingName.NoButter },
                    { 80, ToppingName.PestoInside },
                     { 81, ToppingName.MozzarellaAndRicotta },
                   { 82, ToppingName.RicottaCalzone },
                    { 83, ToppingName.MozzarellaCalzone },
                     { 84, ToppingName.SteakWithOnion },
                    { 90,  ToppingName.Deep },
                     { 91,  ToppingName.Carrots },
                      { 93, ToppingName.NoSauce },
                          { 94, ToppingName.LightSauce },
                       { 96, ToppingName.OutFirst },
                       { 97, ToppingName.SliceCutInHalfSamePlate },
                        { 98, ToppingName.SliceCutInHalfSepPlate },
                        { 99, ToppingName.NoDressing },
                       { 100, ToppingName.Joiner },
                        { 101, ToppingName.CutInto12 },
                         { 102, ToppingName.FiftyCentsUpcharge },
                 { 103, ToppingName.NoCheese },
                { 105, ToppingName.Cheese },
                  { 106, ToppingName.PizzaSauceInside },
                   { 107, ToppingName.SaladWithOrder },
                   {108, ToppingName.NoRicotta },
                {109, ToppingName.NoMozarella },
                { 110, ToppingName.KidCook },
                   { 122, ToppingName.LightRicotta },
                     { 123, ToppingName.LightMozarella },
                      { 124, ToppingName.NoCut },
                       { 126, ToppingName.TakeoutBring2Table },
                         { 128, ToppingName.PizzaSauceInside },
                 { 132, ToppingName.Mushrooms },
                  { 135, ToppingName.NoNutsSeedsOk },
                     { 139, ToppingName.PecansWalnuts },
                   { 141, ToppingName.Sausage },
                     { 145, ToppingName.Jalapenos },
                     { 146, ToppingName.NoNutsNoSeeds },
                 { 148, ToppingName.ExtraRicottaCalzone },
                { 149, ToppingName.ExtraMozarellaCalzone  },
                 { 150, ToppingName.TakeoutKeepInKitch },
                { 151, ToppingName.HalfMajor },
                { 153, ToppingName.WithSalad },
                { 154, ToppingName.PestoInsteadOfPizzaSauce },
                { 155, ToppingName.GlutenFreeIndyOnly }
            };
        }
        private static void CreateToppingDbIdDictionary()
        {
            //TODO - COmplete this or figure out how to do automatically....
            toppingDbIdDictionary = new Dictionary<ToppingName, decimal>
            {
                { ToppingName.Almonds, 0 },
                { ToppingName.Anchovies, 27 },
                  { ToppingName.Apples, 0 },
                { ToppingName.Artichokes, 31 },
                { ToppingName.Bacon, 43 },
                { ToppingName.BananaPeppers, 32 },
                { ToppingName.Basil, 17 },
                { ToppingName.Beef, 24 },
                { ToppingName.BlackOlives, 23 },
                 { ToppingName.ButterOk, 75 },
                { ToppingName.CutInto12, 101 },
                { ToppingName.Broccoli, 34 },
                { ToppingName.Carrots, 40 },
                 { ToppingName.Cheese, 105 },
                   { ToppingName.CrispyCook, 53 },
                 { ToppingName.Deep, 90 },
                { ToppingName.DAIYA, 61 },
                { ToppingName.ExtraCheese, 11 },
                { ToppingName.ExtraMozarellaCalzone, 149 },
                { ToppingName.ExtraPSauceOP, 16 },
                { ToppingName.ExtraPSauceOS, 1 },
                { ToppingName.ExtraRicottaCalzone, 148 },
                { ToppingName.Feta, 15 },
                { ToppingName.Garlic, 47 },
                { ToppingName.GreenOlives, 26 },
                { ToppingName.GreenPeppers, 13 },
                 { ToppingName.Lettuce, 9 },
                { ToppingName.HalfMajor, 151 },
                { ToppingName.Ham, 14 },
                { ToppingName.Jalapenos, 38 },
                  { ToppingName.KidCook, 110 },
                 { ToppingName.LightCook, 52  },
                 { ToppingName.LightSauce, 94 },
                { ToppingName.LightMozarella, 123 },
                { ToppingName.LightRicotta, 122 },
                {ToppingName.Major, 18 },
                { ToppingName.Meatballs, 20 },
                { ToppingName.Mushrooms, 132 },
                { ToppingName.NoButter, 76 },
                { ToppingName.NoSauce, 93 },
                 { ToppingName.NoRicotta, 108 },
                { ToppingName.NoMozarella, 109 },
                { ToppingName.NoCheese, 103 },
                { ToppingName.Onion, 44 },
                { ToppingName.PestoTopping, 67 },
                { ToppingName.Pepperoni, 12 },
                { ToppingName.Pineapple, 39 },
                { ToppingName.RedOnions, 48 },
                { ToppingName.Ricotta, 41 },
                { ToppingName.RicottaCalzone, 82 },
                { ToppingName.RoastedRedPepper, 29 },
                    { ToppingName.SaladWithOrder, 107 },
                { ToppingName.SliceCutInHalfSamePlate, 97 },
                { ToppingName.SliceCutInHalfSepPlate, 98 },
                { ToppingName.TakeoutBring2Table, 126 },
                { ToppingName.TakeoutKeepInKitch, 150 },
                { ToppingName.Sausage, 141 },
                { ToppingName.Spinach, 42 },
                { ToppingName.Steak, 30 },
                { ToppingName.SundriedTomatoes, 21 },
                { ToppingName.Teese, 62 },
                { ToppingName.TempehBBQ, 37 },
                { ToppingName.TempehOriginal, 36 },
                { ToppingName.Tomatoes, 28 },
                { ToppingName.Zucchini, 33 },
              
               
                { ToppingName.Joiner, 100 },
                { ToppingName.NoCut, 124 },
                { ToppingName.OutFirst, 96 },
                
               
                { ToppingName.GlutenFreeIndyOnly, 155 }
            };
        }

        private static void LoadTableIdAllTablesIndexDictionary()
        {
            tableIdAllTablesIndexDictionary = new Dictionary<decimal, int>();
            foreach (var table in Tables.AllTables)
            {
                if (!tableIdAllTablesIndexDictionary.ContainsKey(table.TableId))
                {
                    tableIdAllTablesIndexDictionary.Add(table.TableId, table.IndexInAllTables);
                }
            }
        }
    }
}
