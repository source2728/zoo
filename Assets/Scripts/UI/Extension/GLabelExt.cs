using FairyGUI;

public static class GLabelExt
{
    public static void SetText(this GLabel textField, int data)
    {
        textField.text = data.ToString();
    }

    public static void SetText(this GLabel textField, string data)
    {
        textField.text = data;
    }
}
