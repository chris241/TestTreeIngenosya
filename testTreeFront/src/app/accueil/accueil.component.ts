import { Component, OnInit } from '@angular/core';
import { TreeService } from '../services/tree-service';
import { Synthese } from '../models/synthese';
import { TestReq } from '../models/test-req';

@Component({
  selector: 'accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {
  syntheses: Synthese[];
  test: TestReq = new TestReq();
  constructor(public service: TreeService) {
  }

  ngOnInit() {
    this.getAllSynthese();
  }
  getAllSynthese() {
    this.service.getAll().subscribe((data) => {
      this.syntheses = data;
    });

  }
  addTree() {
    this.service.create(this.test).subscribe((data) => {
      this.getAllSynthese();
      this.test.categorie = "";
    }, (err) => {
      alert("erreur");
    });

  }
  getExport() {
    this.service.getExport().subscribe((data) => {
      alert(data);
    })
  }
}
