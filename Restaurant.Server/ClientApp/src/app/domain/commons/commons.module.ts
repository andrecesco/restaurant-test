import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaginatorComponent } from '../commons/components/paginator/paginator.component';

@NgModule({
  imports: [
    CommonModule
  ],

  declarations: [
    PaginatorComponent
  ],

  exports: [
    PaginatorComponent
  ],

  providers: [],
})
export class CommonsModule { }
