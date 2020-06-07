import { Component, OnInit } from '@angular/core';
import {GlobalService} from '../../Services/global.service'
@Component({
  selector: 'app-stressmgmt',
  templateUrl: './stressmgmt.component.html',
  styleUrls: ['./stressmgmt.component.css']
})


export class StressmgmtComponent implements OnInit {

  constructor(private globalService : GlobalService) { 
    this.newTodo = '';
    this.todos = [];
  }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }

  //for the to dos list
  newTodo: string;
  todos: any;
  todoObj: any;

  //showing sections booleans
  public div1: boolean= true;
  public div2: boolean= false;
  public videos: boolean= false;
  public workout: boolean= false;
  public books: boolean= false;
  public music :boolean=false;
  public todolist: boolean= false;
  public talk: boolean= false;
  public isMusicOn :boolean 
  //showing sections transitions booleans
  public transition1show: boolean= false;
  public transition2show: boolean= false;
  public transition3show: boolean= false;
  public transition4show: boolean= false;
  public transition5show: boolean= false;
  public transition6show: boolean= false;
  public transition7show: boolean= false;

#region 
    showHome(): void {
      this.div2=false;
      this.transition1show=false;
      this.div1=true;
    }
    toggleMusic():void{
      this.globalService.toggleMusic();
      this.isMusicOn=this.globalService.isMusicOn
    }
    showSuggestionsTransition(): void {
      this.div1=false;
      this.transition1show=true;
    }
    showSuggestions(): void {
      this.transition1show=false;
      this.transition2show=false;
      this.transition3show=false;
      this.transition4show=false;
      this.transition5show=false;
      this.transition6show=false;
      this.transition7show=false;
      this.div2=true;
      this.videos= false;
      this.workout= false;
      this.books= false;
      this.music=false;
      this.todolist= false;
      this.talk= false;
    }

    showVideosTransition(): void {
      this.div2=false;
      this.transition2show=true; 
    }
    showVideos(): void {
      this.transition2show=false;
      this.videos=true;
    }

    showWorkoutTransition(): void {
      this.div2=false;
      this.transition3show=true; 
    }
    showWorkout(): void {
      this.transition3show=false;
      this.workout=true;
    }

    showBooksTransition(): void {
      this.div2=false;
      this.transition4show=true; 
    }
    showBooks(): void {
      this.transition4show=false;
      this.books=true;
    }

    showMusicTransition(): void {
      this.div2=false;
      this.transition5show=true; 
    }
    showMusic(): void {
      this.transition5show=false;
      this.music=true;
    }

    showTodolistTransition(): void {
      this.div2=false;
      this.transition6show=true; 
    }
    showTodolist(): void {
      this.transition6show=false;
      this.todolist=true;
    }

    showChatTransition(): void {
      this.div2=false;
      this.transition7show=true; 
    }
    showChat(): void {
      this.transition7show=false;
      this.talk=true;
    }

#endregion


pictures = [
  {
    id : 1,
    title :'Gift Of Light',
    img : '../../assets/images/small1.jpg',
    msg : 'Didn\'t we all need darkness to find a way towards light?'
  },
  {
    id : 2,
    title :'Being there',
    img : '../../assets/images/small2.jpg',
    msg : '"You\'re unbeatable on your journey till you choose to quit",said Coach Carter'
  },
  {
    id : 3,
    title :'Finding Home',
    img : '../../assets/images/small3.jpg',
    msg : 'She traveled the whole world only to find peace back at the place she had lost it'
  },
  {
    id :4, 
    title :'Pursuit of Wings',
    img : '../../assets/images/small4.jpg',
    msg : 'There was something in Jimmy\'s eyes that day. He wanted to touch the clouds'
  },
  {
    id :5,
    title :'The Princess of 5',
    img : '../../assets/images/small5.jpg',
    msg : 'That expression was of resolve.Lizzy was not coming back till she found her father'
  },
  {
    id :6,
    title :'Citylights',
    img : '../../assets/images/small6.jpg',
    msg : 'Christmas had its own way of lighting up lives and touching hearts'
  }]


  /* 
  TODO LIST SECTION:
  Methods for the to do list: addTodo, deleteTodo, deleteSelectedTodos
  */
  addTodo(event) {
    this.todoObj = {
      newTodo: this.newTodo,
      completed: false
    }
    this.todos.push(this.todoObj);
    this.newTodo = '';
    event.preventDefault();
  }

  deleteTodo(index) {
    this.todos.splice(index, 1);
  }

  deleteSelectedTodos() {
    //need ES5 to reverse loop in order to splice by index
    for(var i=(this.todos.length -1); i > -1; i--) {
      if(this.todos[i].completed) {
        this.todos.splice(i, 1);
      }
    }
  }


}
