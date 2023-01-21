using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronsManger 
{
    public static List<Electron> Electrons = new List<Electron>();
    public static void AddElectron(Electron electron)
    {
        Electrons.Add(electron);
    }
}
