import { Component, OnInit } from '@angular/core';
import {GlobalService} from '../../Services/global.service'

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.css']
})
export class VideosComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }
  public isMusicOn :boolean 
  //showing sections booleans
  public div1: boolean= true;
  public videos: boolean= false;

  //showing sections transitions booleans
  public transition2show: boolean= false;
  public transition3show: boolean= false;

#region 
    showVideosTransition(): void {
      this.div1=false;
      this.transition2show=true; 
    }
    toggleMusic():void{
      this.globalService.toggleMusic();
      this.isMusicOn=this.globalService.isMusicOn
    }
    showWorkoutTransition(): void {
      this.transition2show=false; 
      this.transition3show=true; 
    }
    showVideos(): void {
      this.transition3show=false;
      this.videos=true;
    } 
#endregion

}
