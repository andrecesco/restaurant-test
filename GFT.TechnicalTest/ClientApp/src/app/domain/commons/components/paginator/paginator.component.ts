import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

import { Page } from '../../models/page.model';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {
  @Input() public data: Page<any>;
  @Output() refresh: EventEmitter<number>;

  public currentPage: number;

  constructor() {
    this.currentPage = 0;
    this.refresh = new EventEmitter();
  }

  ngOnInit() {
    this.currentPage = this.data.number;
  }

  hasNextPage() {
    const total = this.data.total - 1;
    return total > 0 && this.data.number <= total;
  }

  hasPreviousPage() {
    return this.data.number > 0;
  }

  goNextPage() {
    this.currentPage = this.currentPage + 1;
    this.doEmit();
  }

  goPreviousPage() {
    this.currentPage = this.currentPage - 1;
    this.doEmit();
  }

  getCurrentStatus() {
    return `${this.data.number + 1} / ${this.data.total}`;
  }

  private doEmit() {
    this.refresh.emit(this.currentPage);
  }
}
