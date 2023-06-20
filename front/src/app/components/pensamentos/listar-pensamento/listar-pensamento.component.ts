import { Pensamento } from 'src/app/components/pensamentos/models/pensamento';
import { Component } from '@angular/core';
import { PensamentoService } from '../pensamento.service';

@Component({
  selector: 'app-listar-pensamento',
  templateUrl: './listar-pensamento.component.html',
  styleUrls: ['./listar-pensamento.component.css']
})
export class ListarPensamentoComponent {
  listaPensamentos: Pensamento[] = []

  constructor(
    private readonly service: PensamentoService
  ) {}

  ngOnInit() {
    this.service.listar().subscribe((pagedPensamentos) => {
      this.listaPensamentos = pagedPensamentos.data
    });
  }
}
