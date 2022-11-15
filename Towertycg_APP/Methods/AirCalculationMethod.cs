using System;
using Towertycg_APP.Modules;

namespace Towertycg_APP.Methods
{
    public class AirCalculationMethod
    {
        /// <summary>
        /// 計算壓力(p)，單位(kPa)
        /// </summary>
        /// <param name="Altitude">海拔高度(m)</param>
        /// <returns></returns>
        public static double Cal_P(double Altitude)
        {
            double value = Math.Round(101.325 * Math.Pow(1 - 2.5577 * Math.Pow(10, -5) * Altitude, 5.2559), 3);
            return value;
        }
        /// <summary>
        /// 計算飽和狀態之水蒸氣分壓(Pws)，單位(kPa)
        /// </summary>
        /// <param name="T_db">乾球溫度(°C)</param>
        /// <returns></returns>
        public static double Cal_Pws(double T_db)
        {
            double TK = T_db + 273.15;
            double n1 = 0.11670521452767 * Math.Pow(10, 4);
            double n2 = -0.72421316732106 * Math.Pow(10, 6);
            double n3 = -0.17073846940092 * Math.Pow(10, 2);
            double n4 = 0.1202082470247 * Math.Pow(10, 5);
            double n5 = -0.32325550322333 * Math.Pow(10, 7);
            double n6 = 0.1491510861353 * Math.Pow(10, 2);
            double n7 = -0.48232657361591 * Math.Pow(10, 4);
            double n8 = 0.40511340542057 * Math.Pow(10, 6);
            double n9 = -0.23855557567849 * Math.Pow(10, 0);
            double n10 = 0.65017534844798 * Math.Pow(10, 3);

            double theta = TK + n9 / (TK - n10);

            double a = Math.Pow(theta, 2) + n1 * theta + n2;
            double b = n3 * Math.Pow(theta, 2) + n4 * theta + n5;
            double c = n6 * Math.Pow(theta, 2) + n7 * theta + n8;
            double Pws = Math.Round(1000 * Math.Pow(2 * c / (-1 * b + Math.Pow(Math.Pow(b, 2) - 4 * a * c, 0.5)), 4), 3);
            return Pws;
        }

        /// <summary>
        /// 計算飽和濕空氣之濕度比，單位(kg/kg)
        /// </summary>
        /// <param name="P1">大氣壓力、全壓(kPa)</param>
        /// <param name="P2">水蒸氣分壓、飽和狀態之水蒸氣分壓(kPa)</param>
        /// <returns></returns>
        public static double Cal_W(double P1, double P2)
        {

            double W = Math.Round(0.621945 * P2 / (P1 - P2), 3);
            return W;
        }
        /// <summary>
        /// 計算濕度比，單位(kg/kg)
        /// </summary>
        /// <param name="Wss">濕球溫度條件下之飽和狀態濕度比(kg/kg)</param>
        /// <param name="T_db">乾球溫度(°C)</param>
        /// <param name="T_wb">濕球溫度(°C)</param>
        /// <returns></returns>
        public static double Cal_W1(double Wss, double T_db, double T_wb)
        {
            double W1 = Math.Round(((2501 - 2.326 * T_wb) * Wss - 1.006 * (T_db - T_wb)) / (2501 + 1.86 * T_db - 4.186 * T_wb), 3);
            return W1;
        }
        /// <summary>
        /// 計算水蒸氣分壓，單位(kPa)
        /// </summary>
        /// <param name="P1">大氣壓力、全壓(kPa)</param>
        /// <param name="W">濕度比(kg/kg)</param>
        /// <returns></returns>
        public static double Cal_Pw(double P1, double W)
        {
            double Pw = Math.Round((P1 * W) / (0.621945 + W), 3);
            return Pw;
        }
        /// <summary>
        /// 計算相對濕度，單位(%)
        /// </summary>
        /// <param name="P1">水蒸氣分壓(kPa)</param>
        /// <param name="P2">飽和狀態下之水蒸氣分壓(kPa)</param>
        /// <returns></returns>
        public static double Cal_RH(double P1, double P2)
        {
            double RH = Math.Round(P1 / P2 * 100, 1);
            return RH;
        }
        /// <summary>
        /// 計算比容，單位(m3/kg)
        /// </summary>
        /// <param name="T_db">乾球溫度(°C)</param>
        /// <param name="P1">大氣壓力、全壓(kPa)</param>
        /// <param name="P2">水蒸氣分壓(kPa)</param>
        /// <returns></returns>
        public static double Cal_v(double T_db, double P1, double P2)
        {
            double R = 8314.742;
            double T = T_db + 273.15;
            double v = Math.Round((R * T / (28.966 * (P1 - P2))) / 1000, 3);
            return v;
        }
        /// <summary>
        /// 計算焓，單位(kJ/kg)
        /// </summary>
        /// <param name="T_db">乾球溫度(°C)</param>
        /// <param name="W">濕度比(kg/kg)</param>
        /// <returns></returns>
        public static double Cal_h(double T_db, double W)
        {
            double h = Math.Round(1.006 * T_db + W * (2501 + 1.86 * T_db), 3);
            return h;
        }
        /// <summary>
        /// 計算濕球溫度，單位(°C)
        /// </summary>
        /// <param name="T_db">乾球溫度(°C)</param>
        /// <param name="P"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public static double Cal_twb(double T_db, double P, double W, double RH)
        {
            double twb = 0;
            if (RH >= 100)
            {
                twb = T_db;
            }
            else
            {
                for (int Twb_test = -10000; Twb_test < 50001; Twb_test++)
                {
                    twb = Convert.ToDouble(Twb_test) / 1000;
                    double Pwss = Cal_Pws(twb);
                    double Wss = Cal_W(P, Pwss);
                    double W_test = Cal_W1(Wss, T_db, twb);
                    double error_rate = Math.Round(((W_test - W) / W) * 100, 2);
                    if (error_rate <= 0.01 & error_rate >= -0.01)
                    {
                        break;
                    }
                }
            }
            return Math.Round(twb, 1);
        }
        /// <summary>
        /// 計算露點溫度
        /// </summary>
        /// <param name="T_db">乾球溫度</param>
        /// <param name="RH">相對溼度</param>
        /// <returns></returns>
        public static double Cal_td(double T_db, double RH)
        {
            double td = 0;
            if (RH != 0)
            {
                var y = (17.27 * T_db) / (237.7 + T_db) + Math.Log(RH / 100);
                td = Math.Round((237.7 * y) / (17.27 - y), 1);
            }
            return td;
        }
        /// <summary>
        /// 絕對溼度 (kg/m3)
        /// </summary>
        /// <param name="T_db">乾球溫度</param>
        /// <param name="pw">水蒸氣分壓</param>
        /// <returns></returns>
        public static double Cal_ah(double T_db, double pw)
        {
            double ah = Math.Round(217 * pw / (273.15 + T_db) / 100, 3);
            return ah;
        }
        /// <summary>
        /// 計算
        /// </summary>
        /// <param name="z">海拔高度</param>
        /// <param name="T_db">乾球溫度</param>
        /// <param name="RH">相對溼度(%)</param>
        public static AirCalculationClass Calculation(double z, double T_db, double RH)
        {
            double p = Cal_P(z);//壓力
            double pws = Cal_Pws(T_db);//飽和狀態之水蒸氣分壓
            double pw = pws * (RH / 100);//水蒸氣分壓
            double w = Cal_W(p, pw);//濕度比
            double ws = Cal_W(p, pws);//飽和濕空氣之濕度比
            double h = Cal_h(T_db, w);//濕空氣之焓值
            double v = Cal_v(T_db, p, pw);//濕空氣之比容\
            double td = Cal_td(T_db, RH);//露點溫度
            double AH = Cal_ah(T_db, pw);//絕對溼度
            double twb = Cal_twb(T_db, p, w, RH);//計算濕球溫度
            double pwss = Cal_Pws(twb);//濕球溫度下，飽和狀態之水蒸氣分壓
            double wss = Cal_W(p, pwss);//濕球溫度下，飽和狀態之濕度比
            //Console.WriteLine($"海拔高度 {z}");
            //Console.WriteLine($"乾球溫度 {T_db}");
            //Console.WriteLine($"濕球溫度 {twb}");
            //Console.WriteLine($"壓力 {p}");
            //Console.WriteLine($"水蒸氣分壓 {pw}");
            //Console.WriteLine($"飽和狀態之水蒸氣分壓 {pws}");
            //Console.WriteLine($"濕球溫度下，飽和狀態之水蒸氣分壓 {pwss}");
            //Console.WriteLine($"濕度比 {w}");
            //Console.WriteLine($"飽和濕空氣之濕度比 {ws}");
            //Console.WriteLine($"濕球溫度下，飽和狀態之濕度比 {wss}");
            //Console.WriteLine($"濕空氣之相對濕度 {RH}");
            //Console.WriteLine($"濕空氣之焓值 {h}");
            //Console.WriteLine($"濕空氣之比容 {v}");
            //Console.WriteLine($"露點溫度 {td}");
            //Console.WriteLine($"絕對溼度 {AH}");

            /*建立物件暫存數值*/
            AirCalculationClass airCalculationClass = new AirCalculationClass();
            airCalculationClass.z = z;//海拔高度
            airCalculationClass.T_DB = T_db;//乾球溫度
            airCalculationClass.RH = RH;//相對溼度(%)
            airCalculationClass.P = p;//壓力 (kPa)
            airCalculationClass.PWS = pws;//飽和狀態之水蒸氣分壓
            airCalculationClass.PW = pw;//水蒸氣分壓
            airCalculationClass.W = w;//濕度比
            airCalculationClass.WS = ws;//飽和濕空氣之濕度比
            airCalculationClass.h = h;//濕空氣之焓值
            airCalculationClass.v = v;//濕空氣之比容
            airCalculationClass.TWB = twb;//計算濕球溫度
            airCalculationClass.PWSS = pwss;//濕球溫度下，飽和狀態之水蒸氣分壓
            airCalculationClass.WSS = wss;//濕球溫度下，飽和狀態之濕度比
            airCalculationClass.Td = td;//露點溫度
            airCalculationClass.AH = AH;//絕對溼度 (kg/m3)
            return airCalculationClass;
        }
    }
}
