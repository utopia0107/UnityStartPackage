using System;

[AttributeUsage(AttributeTargets.Field)]
public class BindComponet : Attribute
{
    public readonly string GameObejectName;

    public BindComponet(string InGameObjecName)
    {
        GameObejectName = InGameObjecName;
    }
}