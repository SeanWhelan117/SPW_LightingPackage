using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using System;
using UnityEngine.Rendering.Universal;

public class Tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }


    [UnityTest]
    public IEnumerator LightFlickerFinishedTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/player"));
        GameObject light = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LightFixture"));

        Light2D lighting = light.GetComponentInChildren<Light2D>();
        lighting.enabled = true;

        bool before = lighting.enabled;
        player.transform.position = new Vector3(1, 1, 1);
        light.transform.position = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2.0f);

        bool after = lighting.enabled;


        Assert.AreEqual(before, after);
    }

}
