using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class DisplayDropdown : MonoBehaviour {

    public bool listResolutions = true;

    private DisplayManager dm;
    private List<int> widths, heights, refreshRate;

    private void Start()
    {
        dm = DisplayManager.instance;
        TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
        List<string> r = new List<string>();

        if (listResolutions)
        {
            widths = new List<int>();
            heights = new List<int>();
            foreach (Resolution res in dm.resolutions)
            {
                r.Add($"{res.width} x {res.height}");
            }
        }
        else
        {
            refreshRate = new List<int>();
            foreach (Resolution res in dm.resolutions)
            {
                r.Add(res.refreshRate.ToString() + "hz");
                refreshRate.Add(res.refreshRate);
            }
        }

        r = r.Distinct().ToList();

        if (listResolutions)
        {
            foreach (string res in r)
            {
                widths.Add(Int32.Parse(res.Split('x')[0].Trim(' ')));
                heights.Add(Int32.Parse(res.Split('x')[1].Trim(' ')));
            }
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(r);

    }

    public void UpdateSelectedRes(int value)
    {
        dm.pendingHeight = heights[value];
        dm.pendingWidth = widths[value];
    }

    public void UpdateSelectedRefreshRate(int value)
    {
        dm.pendingRefreshRate = refreshRate[value];
    }
    
    private List<int> RemoveDuplicates(List<int> list)
    {
        return list.Distinct().ToList();
    }

}
