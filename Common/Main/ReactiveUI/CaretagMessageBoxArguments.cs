namespace Caretag_Class.ReactiveUI
{
    public class CaretagMessageBoxArguments
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsWarning { get; set; }
        public CaretagMessageBoxOptions Options { get; set; }
        
    }

    public enum CaretagMessageBoxResult
    {
        Ok,
        Cancel,
        All,
        Yes,
        No
    }

    public enum CaretagMessageBoxOptions
    {
        Ok,
        OkCancel,
        YesNoCancel,
        YesNoAll,
        YesNo
    }
}
