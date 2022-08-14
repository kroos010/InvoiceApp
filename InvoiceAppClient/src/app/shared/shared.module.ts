import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SearchFilterPipe } from './pipes/search-filter.pipe';
import { InactivityAlertComponent } from './components/inactivity-alert/inactivity-alert.component';



@NgModule({
  declarations: [
    SearchFilterPipe,
    InactivityAlertComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SearchFilterPipe,

    // Components
    InactivityAlertComponent
  ]
})
export class SharedModule { }
