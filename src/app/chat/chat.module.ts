import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatDialogComponent } from './chat/chat-dialog/chat-dialog.component';
import { FormsModule } from '@angular/forms';
 import { ChatService } from './chat.service';
 import {MatCardModule} from '@angular/material/card';
 
@NgModule({
  declarations: [ChatDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule
  ],   
  exports: [ ChatDialogComponent ],  
  providers: [ChatService]
   
  })
   
  export class ChatModule { }