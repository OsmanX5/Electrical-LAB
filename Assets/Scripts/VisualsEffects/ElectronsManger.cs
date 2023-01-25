using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronsManger :MonoBehaviour
{
    public static List<Electron> Electrons = new List<Electron>();
    public List<Electron> elects;
    void Update()
    {
        elects = Electrons;
    }
    public static void AddElectron(Electron electron)
    {
        Electrons.Add(electron);
    }
    public static void RemoveElectron(Electron electron)
    {
        Electrons.Remove(electron);
    }
    public static void DeletAllElectrons()
    {
        if (Electrons.Count < 1) return;
        for(int i = 0; i < Electrons.Count; i++)
        {
            Electrons[i].delet();
        }
    }
}
