using System;
using UnityEngine;


namespace Utils { 
  public static class PathCutter
  {
    public static string CutPath(this String thisString, string targetFolder, bool inclTargetFolder = true)
    {
      int index = thisString.IndexOf(targetFolder);
      if (index != -1)
      {
        string newPath = thisString.Substring(index);

        if (!inclTargetFolder)
        {
          newPath = newPath.Replace(targetFolder + "/", string.Empty);
        }
        return newPath;
      }
      else
      {
        Console.WriteLine("Folder not found in path.");
      }

      return string.Empty;
    }
  }
}