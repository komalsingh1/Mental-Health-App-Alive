import { BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule} from  '@angular/material/toolbar';
import { MatIconModule} from  '@angular/material/icon';
import { MatSidenavModule } from  '@angular/material/sidenav';
import {MatButtonModule } from  '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatListModule } from  '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule } from '@angular/forms';
import { ChatModule } from './chat/chat.module';
import { HttpClientModule } from "@angular/common/http";
import { AppComponent } from './app.component';
import { BlogsComponent } from './Components/blogs/blogs.component';
import { MusicComponent } from './Components/music/music.component';
import { MemesComponent } from './Components/memes/memes.component';
import { SelfassessmentComponent } from './Components/selfassessment/selfassessment.component';
import { OppurtunitiesComponent } from './Components/oppurtunities/oppurtunities.component';
import { SkillsComponent } from './Components/skills/skills.component';
import { ContactusComponent } from './HelperPages/contactus/contactus.component';
import { AboutComponent } from './HelperPages/about/about.component';
import { HomeComponent } from './Components/home/home.component';
import { PagenotfoundComponent } from './ErrorHandlers/pagenotfound/pagenotfound.component';
import { NopermissionsComponent } from './ErrorHandlers/nopermissions/nopermissions.component';
import { StressmgmtComponent } from './Components/stressmgmt/stressmgmt.component';
import { AssessmentComponent } from './Components/selfassessment/assessment/assessment.component';
import { VideosComponent } from './Components/videos/videos.component';
import { QuestionComponent } from './Components/selfassessment/assessment/question/question.component';
import { ResultComponent } from './Components/selfassessment/assessment/result/result.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogsComponent,
    MusicComponent,
    MemesComponent,
    SelfassessmentComponent,
    OppurtunitiesComponent,
    SkillsComponent,
    ContactusComponent,
    AboutComponent,
    HomeComponent,
    PagenotfoundComponent,
    NopermissionsComponent,
    StressmgmtComponent,
    VideosComponent,
    AssessmentComponent,
    QuestionComponent,
    ResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    FlexLayoutModule,
    MatFormFieldModule,
    FormsModule,
    ChatModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
