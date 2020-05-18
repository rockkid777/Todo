using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models {
  public class TodoItem {
    public int ID { get; set; }
    public string Text { get; set; }
    public bool IsComplete { get; set; }
  }
}
