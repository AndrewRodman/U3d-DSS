using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TreeTracker : MonoBehaviour
{

    public Dictionary<int, TreeData> treeMap;

    public int id = 0;

    public Slider carbonSlider;

    public Slider stormwaterSlider;
    public Slider stormSavingsSlider;

    public Text carbonValue;
    public Text stormwaterValue;
    public Text stormwaterSavingsValue;

    // Use this for initialization
    void Start()
    {
        treeMap = new Dictionary<int, TreeData> { };
    }


    public void Reset()
    {
        treeMap = new Dictionary<int, TreeData> { };
        UpdateMetrics();
    }

    public int AddTree(TreeData tree)
    {
        int treeId = id;
        treeMap.Add(treeId, tree);
        UpdateMetrics();

        id++;
        return treeId;
    }

    public void RemoveTree(int id)
    {
        treeMap.Remove(id);
        UpdateMetrics();
    }

    private void UpdateMetrics()
    {
        var carbon = treeMap.Aggregate(0f, ((acc, tree) => tree.Value.carbon + acc));
        var stormwater = treeMap.Aggregate(0f, ((acc, treeMap) => treeMap.Value.stormwater + acc));
        var stormwaterSavings = treeMap.Aggregate(0f, ((acc, treeMap) => treeMap.Value.Stormsavings + acc));

        var metricsList = new List<float>();
        metricsList.Add(carbon);
        metricsList.Add(stormwater);
        metricsList.Add(stormwaterSavings);


        UpdateMax(metricsList);

        carbonSlider.value = carbon;
        stormwaterSlider.value = stormwater;
        stormSavingsSlider.value = stormwaterSavings;

        carbonValue.text = string.Format("Carbon: {0}lb/year", carbon);
        stormwaterValue.text = string.Format("Stormwater: {0}gal/year", stormwater);
        stormwaterSavingsValue.text = string.Format("Stormwater Savings: ${0}/year", stormwaterSavings);
    }


    private void UpdateMax(List<float> values)
    {
        var max = values.Max();

        carbonSlider.maxValue = max;
        stormwaterSlider.maxValue = max;
        stormSavingsSlider.maxValue = max;
    }

}
