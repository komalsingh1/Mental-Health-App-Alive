import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BlogsComponent } from './Components/blogs/blogs.component';
import { MusicComponent } from './Components/music/music.component';
import { VideosComponent } from './Components/videos/videos.component';
import { MemesComponent } from './Components/memes/memes.component';
import { SelfassessmentComponent } from './Components/selfassessment/selfassessment.component';
import { OppurtunitiesComponent } from './Components/oppurtunities/oppurtunities.component';
import { SkillsComponent } from './Components/skills/skills.component';
import { ContactusComponent } from './HelperPages/contactus/contactus.component';
import { AboutComponent } from './HelperPages/about/about.component';
import { HomeComponent } from './Components/home/home.component';
import { StressmgmtComponent } from './Components/stressmgmt/stressmgmt.component';
import { PagenotfoundComponent } from './ErrorHandlers/pagenotfound/pagenotfound.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'blogs', component: BlogsComponent },
  { path: 'memes', component: MemesComponent },
  { path: 'music', component: MusicComponent },
  { path: 'videos', component: VideosComponent },
  { path: 'oppurtunities', component: OppurtunitiesComponent },
  { path: 'selfassessment', component: SelfassessmentComponent },
  { path: 'skills', component: SkillsComponent },
  { path: 'contactus', component: ContactusComponent },
  { path: 'about', component: AboutComponent },
  {path : 'stressmgmt', component : StressmgmtComponent},
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
