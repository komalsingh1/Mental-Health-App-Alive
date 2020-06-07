import { Component, OnInit } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { trigger,state,style,transition,animate } from '@angular/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {GlobalService} from '../../Services/global.service'

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }
  
  //showing sections booleans
  public div1: boolean= true;
  public books: boolean= false;
  public isMusicOn :boolean 
  //showing sections transitions booleans
  public transition4show: boolean= false;

#region 
   showBooksTransition(): void {
      this.div1=false;
      this.transition4show=true; 
    }
    toggleMusic():void{
      this.globalService.toggleMusic();
      this.isMusicOn=this.globalService.isMusicOn
    }
    showBooks(): void {
      this.transition4show=false;
      this.books=true;
    }

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
    },
    {
      id :7,
      title :'The View from above',
      img : '../../assets/images/small7.jfif',
      msg : 'Little Eddy sits on daddy\'s shoulder to find a breathtaking view infront'
    },
    {
      id :8,
      title :'Solace',
      img : '../../assets/images/small8.jpg',
      msg : '"There is no other way than to resign Miss",said the manager.'
    },
    {
      id :9,
      title :'TOPSY-TURVY',
      img : '../../assets/images/small9.jpg',
      msg : 'My vision was blurred.The fatal drug had made me weak..Where was I?'
    },
    {
      id :10,
      title :'Life without a mask',
      img : '../../assets/images/small10.jpg',
      msg : 'There was no turning back to a life that enslaved him.'
    },
    {
      id :11,
      title :'Blinded by lights',
      img : '../../assets/images/small11.jpg',
      msg : 'Nostalgia and pangs of past!Some stories were never told.'
    },
    {
      id :12,
      title :'Panorama',
      img : '../../assets/images/small12.jfif',
      msg : 'Mild was no word for art.Boundaries were made to be pushed.'
    },
    {
      id :13,
      title :'Wasted love',
      img : '../../assets/images/small13.jpg',
      msg : 'Two wrong atoms collided and together they radiated infinite.'
    },
    {
      id :14,
      title :'Counting days',
      img : '../../assets/images/small14.jpg',
      msg : 'My days remaining were few.The world would not feel my loss.'
    },
    {
      id :15,
      title :'Travelling to Mars',
      img : '../../assets/images/small15.jfif',
      msg : '4 Bottles down and still not full.The rebel was a gift to science.'
    },
    {
      id :16,
      title :'From this angle',
      img : '../../assets/images/small16.jpg',
      msg : 'The deadliest of god\'s creatures often came in disguise'
    },
    {
      id :17,
      title :'Woman of her word',
      img : '../../assets/images/small17.jpg',
      msg : 'She drifted away like lightening.She entered like paradise.'
    },
    {
      id :18,
      title :'Merry-Go-Round',
      img : '../../assets/images/small18.jpg',
      msg : 'The ride was never safe but it was worth the risk.'
    }
  ];


}


