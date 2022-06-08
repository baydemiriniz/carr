using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public static class EventManagerTest
{
    private static StringKey stringKey = new StringKey{key = "Tet"};
    private static IntKey intKey = new IntKey(){key = 3};
    
    [Test]
    public static void StringKeyAdd_Test()
    {
        EventManager.Add(stringKey, StringAddKeyTest);
    }
    
    [Test]
    public static void StringKeyTrigger_Test()
    {
        EventManager.Trigger(stringKey);
    }
    
    [Test]
    public static void StringKeyRemove_Test()
    {
        EventManager.Remove(stringKey, StringAddKeyTest);
    }

    [Test]
    public static void IntKeyAdd_Test()
    {
        EventManager.Add(intKey, IntAddKeyTest);
    }
    
    [Test]
    public static void IntKeyTrigger_Test()
    {
        EventManager.Trigger(intKey);
    }
    
    [Test]
    public static void IntKeyRemove_Test()
    {
        EventManager.Remove(intKey, IntAddKeyTest);
    }
    
    [Test]
    public static void EmptyActionAdd_Test()
    {
        EventManager.Add(stringKey, null);
        LogAssert.Expect(LogType.Error, "Action cannot be NULL");
    }

    [Test]
    public static void EmptyKeyAdd_Test()
    {
        EventManager.Add(null, IntAddKeyTest);
        LogAssert.Expect(LogType.Error, "Key cannot be NULL");
    }

    private static void StringAddKeyTest()
    {
        Debug.Log("string Add key test");
    }   
    private static void IntAddKeyTest()
    {
        Debug.Log("int Add key test");
    }
}
