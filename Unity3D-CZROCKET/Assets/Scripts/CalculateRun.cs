using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateRun : MonoBehaviour
{

    //# include <stdio.h>
    //# include <math.h>
    //#define FREE free
    //#define MALLOC malloc
   public struct Orbit_trajectory
    {
        public double[] x;
        public double[] y;
        public double[] z;
        public double[] vx;
        public double[] vy;
        public double[] vz;
    }
    static Orbit_trajectory orbit_traj;
    static bool flag = false;

    static double mu = 3.986005e+14;//[米立方]/[秒平方]

    public static int Integral_num = 2000;//积分次数 
    static int df_time = 5;//积分间隔
    public static List<double> orbitPosition = new List<double>();

    /*
        计算卫星微分
    */
    public static void Compute_Orbit_Dynamics(double[] state, double[] diff)
    {
        double r = Math.Sqrt(state[0] * state[0] + state[1] * state[1] + state[2] * state[2]);
        //卫星位置信息微分
        diff[0] = state[3];
        diff[1] = state[4];
        diff[2] = state[5];

        //卫星速度信息微分
        diff[3] = (-1.0) * mu / Math.Pow(r, 3) * state[0];
        diff[4] = (-1.0) * mu / Math.Pow(r, 3) * state[1];
        diff[5] = (-1.0) * mu / Math.Pow(r, 3) * state[2];
    }

    /*
        使用RK45积分出卫星完整轨迹
    */
    public static void get_orbit_traj()
    {
        double[ ] orbit_d = new double[6];
        double[ ] orbit_s = new double[16];
        double[ ] temp_orbit_s = new double[6];
        double[,] K = new double[4, 6];
        for (int i = 1; i < Integral_num; i++)
        {
            //计算K[0]
            orbit_s[0] = orbit_traj.x[i - 1];
            orbit_s[1] = orbit_traj.y[i - 1];
            orbit_s[2] = orbit_traj.z[i - 1];
            orbit_s[3] = orbit_traj.vx[i - 1];
            orbit_s[4] = orbit_traj.vy[i - 1];
            orbit_s[5] = orbit_traj.vz[i - 1];
            Compute_Orbit_Dynamics(orbit_s, orbit_d);
            for (int j = 0; j < 6; j++)
            {
                K[0,j] = (double)df_time * orbit_d[j];
            }

            //计算K[1]
            for (int j = 0; j < 6; j++)
            {
                temp_orbit_s[j] = orbit_s[j] + 0.5 * K[0,j];
            }
            Compute_Orbit_Dynamics(temp_orbit_s, orbit_d);
            for (int j = 0; j < 6; j++)
            {
                K[1,j] = (double)df_time * orbit_d[j];
            }

            //计算K[2]
            for (int j = 0; j < 6; j++)
            {
                temp_orbit_s[j] = orbit_s[j] + 0.5 * K[1,j];
            }
            Compute_Orbit_Dynamics(temp_orbit_s, orbit_d);
            for (int j = 0; j < 6; j++)
            {
                K[2,j] = (double)df_time * orbit_d[j];
            }

            //计算K[3]
            for (int j = 0; j < 6; j++)
            {
                temp_orbit_s[j] = orbit_s[j] + 1.0 * K[2,j];
            }
            Compute_Orbit_Dynamics(temp_orbit_s, orbit_d);
            for (int j = 0; j < 6; j++)
            {
                K[3,j] = (double)df_time * orbit_d[j];
            }

            //求和
            orbit_traj.x[i] = orbit_traj.x[i - 1] + (K[0,0] + 2.0 * K[1,0] + 2.0 * K[2,0] + K[3,0]) / 6.0;
            orbit_traj.y[i] = orbit_traj.y[i - 1] + (K[0,1] + 2.0 * K[1,1] + 2.0 * K[2,1] + K[3,1]) / 6.0;
            orbit_traj.z[i] = orbit_traj.z[i - 1] + (K[0,2] + 2.0 * K[1,2] + 2.0 * K[2,2] + K[3,2]) / 6.0;
            orbit_traj.vx[i] = orbit_traj.vx[i - 1] + (K[0,3] + 2.0 * K[1,3] + 2.0 * K[2,3] + K[3,3]) / 6.0;
            orbit_traj.vy[i] = orbit_traj.vy[i - 1] + (K[0,4] + 2.0 * K[1,4] + 2.0 * K[2,4] + K[3,4]) / 6.0;
            orbit_traj.vz[i] = orbit_traj.vz[i - 1] + (K[0,5] + 2.0 * K[1,5] + 2.0 * K[2,5] + K[3,5]) / 6.0;
        }

    }

    public static void CalOrbit(double x, double y, double z, double vx ,double vy, double vz)
    {
        if (!flag) {
            orbit_traj.x = new double[Integral_num];
            orbit_traj.y = new double[Integral_num];
            orbit_traj.z = new double[Integral_num];
            orbit_traj.vx = new double[Integral_num];
            orbit_traj.vy = new double[Integral_num];
            orbit_traj.vz = new double[Integral_num];
            flag = true;
        }
        // 初始化
        //Orbit_trajectory orbit_traj;
        orbit_traj.x[0] = x;
        orbit_traj.y[0] = y;
        orbit_traj.z[0] = z;
        orbit_traj.vx[0] = vx;
        orbit_traj.vy[0] = vy;
        orbit_traj.vz[0] = vz;
        //print("start\n");
        get_orbit_traj();
        //print("end\n");
        for (int i = 0; i < Integral_num; i++)
        {
            //print(string.Format("i = {0}, {1:N2}, {2:N2}, {3:N2}, {4:N2}, {5:N2}, {6:N2}\n", i + 1, orbit_traj.x[i], orbit_traj.y[i], orbit_traj.z[i],
            //    orbit_traj.vx[i], orbit_traj.vy[i], orbit_traj.vz[i]));
            orbitPosition.Add(orbit_traj.x[i]);
            orbitPosition.Add(orbit_traj.y[i]);
            orbitPosition.Add(orbit_traj.z[i]);
            orbitPosition.Add(orbit_traj.vx[i]);
            orbitPosition.Add(orbit_traj.vy[i]);
            orbitPosition.Add(orbit_traj.vz[i]);
        }
        //释放
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

}
