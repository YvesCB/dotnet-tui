namespace DotnetTUI
{

  public enum ConsoleChars
  {
    Horizontal = '─',
    Vertical = '│',
    TopRight = '┐',
    BottomRight = '┘',
    BottomLeft = '└',
    TopLeft = '┌'
  }

  class HorizontalLayout
  {
    private int _width;
    private int _height;

    private List<Pane> _panes;

    public HorizontalLayout(int width, int height)
    {
      _width = width;
      _height = height;

      _panes = new List<Pane>();
    }

    public void AddPane(Action Render)
    {
      Pane new_pane = new Pane(_width / _panes.Count, _height);
      _panes.Add(new_pane);
    }
  }

  class Pane
  {
    private int _width;
    private int _height;

    public Pane(int width, int height)
    {
      _width = width;
      _height = height;
    }
  }

  class Tui
  {
    private int _termwidth;
    private int _termheight;

    public Tui(int width, int height)
    {
      _termwidth = width;
      _termheight = height;
    }

    public void RenderText(string text)
    {
      int text_len = text.Length;
    }

    public void DrawBorder()
    {
      // Clear screen
      Console.Clear();

      // Draw first line on top
      Console.Write((char)ConsoleChars.TopLeft);
      for (int i = 0; i < _termwidth - 2; i++)
      {
        Console.Write((char)ConsoleChars.Horizontal);
      }
      Console.Write((char)ConsoleChars.TopRight);

      // Draw all the lines in the middle
      for (int i = 0; i < _termheight - 2; i++)
      {
        Console.Write((char)ConsoleChars.Vertical);
        for (int k = 0; k < _termwidth - 2; k++)
        {
          Console.Write(" ");
        }
        Console.Write((char)ConsoleChars.Vertical);
      }

      // Draw the bottom line
      Console.Write((char)ConsoleChars.BottomLeft);
      for (int i = 0; i < _termwidth - 2; i++)
      {
        Console.Write((char)ConsoleChars.Horizontal);
      }
      Console.Write((char)ConsoleChars.BottomRight);
    }
  }

  class Programm
  {
    static void Main(string[] args)
    {
      int width = Console.WindowWidth;
      int height = Console.WindowHeight;

      Tui tui = new Tui(width, height);

      tui.DrawBorder();

      Console.ReadKey();
    }
  }
}
