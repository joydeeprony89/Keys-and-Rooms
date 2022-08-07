using System;
using System.Collections.Generic;

namespace Keys_and_Rooms
{
  class Program
  {
    static void Main(string[] args)
    {
      var rooms = new List<IList<int>>();
      rooms.Add(new List<int> { 1, 3 });
      rooms.Add(new List<int> { 3, 0, 1 });
      rooms.Add(new List<int> { 2 });
      rooms.Add(new List<int> { 0 });
      Solution s = new Solution();
      var answer = s.CanVisitAllRooms(rooms);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
      HashSet<int> visited = new HashSet<int>();

      Queue<int> q = new Queue<int>();
      q.Enqueue(0);
      while (q.Count > 0)
      {
        var room = q.Dequeue();
        visited.Add(room);
        var keys = rooms[room];
        foreach (int key in keys)
        {
          if (!visited.Contains(key))
            q.Enqueue(key);
        }
      }
      return visited.Count == rooms.Count;
    }
  }
}
