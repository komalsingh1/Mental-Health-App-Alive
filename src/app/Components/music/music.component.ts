import { Component, OnInit } from '@angular/core';
import {GlobalService} from '../../Services/global.service'

@Component({
  selector: 'app-music',
  templateUrl: './music.component.html',
  styleUrls: ['./music.component.css']
})
export class MusicComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }

 //showing sections booleans
 public div1: boolean= true;
 public music :boolean=false;
 public isMusicOn :boolean 

 //showing sections transitions booleans
 public transition5show: boolean= false;

#region 
     showMusicTransition(): void {
     this.div1=false;
     this.transition5show=true; 
   }
   toggleMusic():void{
    this.globalService.toggleMusic();
    this.isMusicOn=this.globalService.isMusicOn
  }
   showMusic(): void {
     this.transition5show=false;
     this.music=true;
   }

}
