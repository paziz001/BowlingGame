import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-round-header',
  templateUrl: './round-header.component.html',
  styleUrls: ['./round-header.component.css']
})
export class RoundHeaderComponent implements OnInit {
  @Input() headerName: string;

  constructor() { }

  ngOnInit() {
  }

}
