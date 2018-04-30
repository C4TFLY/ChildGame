using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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
                widths.Add(res.width);
                heights.Add(res.height);
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

        IEnumerable<string> re = r;
        r = re.Distinct().ToList();
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
}
