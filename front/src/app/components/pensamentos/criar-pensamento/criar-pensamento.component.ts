import { Component } from '@angular/core';
import { CreatePensamentoDto } from '../models/CreatePensamentoDto';
import { PensamentoService } from '../pensamento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-criar-pensamento',
  templateUrl: './criar-pensamento.component.html',
  styleUrls: ['./criar-pensamento.component.css']
})
export class CriarPensamentoComponent {
  pensamento: CreatePensamentoDto = {
    conteudo: '',
    autoria: '',
    modelo: 'modelo1'
  }

  constructor(
    private readonly service: PensamentoService,
    private readonly router: Router
  ) {}

  criarPensamento() {
    this.service.criar(this.pensamento).subscribe(() => {
      this.router.navigate(['/listarPensamento'])
    });
  }

  cancelar() {
    this.pensamento = {
      conteudo: '',
      autoria: '',
      modelo: 'modelo1'
    }
    this.router.navigate(['/listarPensamento'])
  }
}
