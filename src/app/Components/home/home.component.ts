import { Component, OnInit } from '@angular/core';
import {GlobalService} from '../../Services/global.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }
  public isMusicOn :boolean 
  
  toggleMusic():void{
    this.globalService.toggleMusic();
    this.isMusicOn=this.globalService.isMusicOn
  }

}
