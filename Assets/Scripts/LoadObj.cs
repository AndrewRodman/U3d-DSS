using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class LoadObj : MonoBehaviour
{

    public GameObject obj;
    public Image image; //background image
    public GameObject title;
    public GameObject menuCamera;
    public GameObject fpsCamera;
    public bool escOn = false;

    public GameObject metrics;

    public GameObject controls;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && escOn == false)
        {
            //fpsCamera.SetActive(false); //turn fps camera off
            menuCamera.SetActive(true);//turn menu camera on
            title.SetActive(true); //title is showing 
            Cursor.visible = true;
            escOn = true;
            //Color color= image.color;
            //color.a=100; 
            //image.color=color; // makes the color of the background not transparent


        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escOn == true)
        {
            menuCamera.SetActive(false);//turn menu camera on
            title.SetActive(false); //title is showing 
            Cursor.visible = false;
            escOn = false;
        }
    }

    //when the load button is pressed
    public void onClick()
    {
        Color color = image.color;
        color.a = 100;
        image.color = color; // makes the color of the background not transparent
        Destroy(obj);
        metrics.SetActive(false); // turn off metrics
        controls.SetActive(false); // turn off control buttons
        obj = new GameObject();
        FileBrowser.OpenFilePanel("Select Your Landscape", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), null, null, (bool canceled, string filePath) =>
        {
            if (canceled)
            {
                return;
            }
            else
            {
                Cursor.visible = false; // hide cursor
                metrics.SetActive(true); // show metrics
                controls.SetActive(true); // show controls
                Debug.Log("Got to here with path: " + filePath);
                title.SetActive(false); //title is not showing 
                color.a = 0;
                image.color = color; // makes the color of the background transparent
                obj = OBJLoader.LoadOBJFile(filePath);
                obj.transform.position = new Vector3(0, -40, 300);
                obj.transform.Rotate(new Vector3(0, -90, 0));
                fpsCamera.SetActive(true); //turn fps camera on
                menuCamera.SetActive(false);//turn menu camera off

                //sets the fps camera position to where the obj was loaded 
                fpsCamera.transform.position = new Vector3(0, -40, 300);
                MeshCollider Collider = obj.AddComponent<MeshCollider>(); //adding mesh collider to obj

                //adds mesh collider to all children of obj loaded
                foreach (Transform child in obj.transform)
                {
                    child.gameObject.AddComponent<MeshCollider>();
                }

				ResetTrees();

            }
        });

    }

    private void ResetTrees()
    {

        //removes any trees still in the landscape
        foreach (GameObject tree in GameObject.FindGameObjectsWithTag("Tree"))
        {
            Destroy(tree);
        }

        GameObject trackerHolder = GameObject.FindGameObjectWithTag("TreeTracker");
        TreeTracker treeTracker = trackerHolder.GetComponent(typeof(TreeTracker)) as TreeTracker;

        treeTracker.Reset();
    }
}
