using FairyGUI;

public static class GTextFieldExt
{
    public static void SetValue(this GTextField textField, int data)
    {
        textField.SetVar("value", data.ToString()).FlushVars();
    }

    public static void SetValue(this GTextField textField, string data)
    {
        textField.SetVar("value", data).FlushVars();
    }

    public static void SetCurAndMax(this GTextField textField, int cur, int max)
    {
        textField.SetVar("cur", cur.ToString()).SetVar("max", max.ToString()).FlushVars();
    }

    public static void SetText(this GTextField textField, int data)
    {
        textField.text = data.ToString();
    }

    public static void SetText(this GTextField textField, string data)
    {
        textField.text = data;
    }
}
