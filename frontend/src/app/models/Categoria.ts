import { Tipo } from './Tipo';

export class Categoria {
  id: number;
  nome: string;
  icone: string;
  tipoId: number;
  tipo: Tipo;
}
