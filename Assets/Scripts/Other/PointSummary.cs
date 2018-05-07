using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSummary : MonoBehaviour {

    private string p_0, p_1_1, p_1_2, p_2_1, p_2_2;
    private bool p1_extends, p2_extends;

    private void Awake()
    {
        LocalizationManager lm = LocalizationManager.instance;
        p_0 = lm.GetLocalizedValue("point_summary_0");
        p_1_1 = lm.GetLocalizedValue("point_summary_1_1");
        p_2_1 = lm.GetLocalizedValue("point_summary_2_1");

        if (lm.ValueExistsForKey("point_summary_1_2"))
        {
            p_1_2 = lm.GetLocalizedValue("point_summary_1_2");
            p1_extends = true;
        }

        if (lm.ValueExistsForKey("point_summary_2_2"))
        {
            p_2_2 = lm.GetLocalizedValue("point_summary_2_2");
            p2_extends = true;
        }
    }

    private void OnEnable()
    {
        TextMeshProUGUI summary = GetComponent<TextMeshProUGUI>();

        string part1 = p1_extends ? (Scoring.PlayerScore > 1 ? p_1_1 : p_1_2) : p_1_1;
        string part2 = p2_extends ? (Scoring.FishEaten > 1 ? p_2_1 : p_2_2) : p_2_1;

        summary.text = $"{p_0} {Scoring.PlayerScore} {part1} {Scoring.FishEaten} {part2}";
    }

}
