import { VendaService } from "./../../../../services/venda.service";
import { ItemVenda } from "src/app/models/item-venda";
import { Pagamento } from "./../../../../models/pagamento";
import { Component, OnInit } from "@angular/core";
import { PagamentoService } from "src/app/services/pagamento.service";
import { ItemService } from "src/app/services/item.service";
import { Venda } from "src/app/models/venda";
import { Router } from "@angular/router";

@Component({
    selector: "app-final",
    templateUrl: "./final.component.html",
    styleUrls: ["./final.component.css"],
})
export class FinalComponent implements OnInit {
    array: Pagamento[] = [];
    pagamento!: string;
    usuario!: string;
    itens!: any;

    constructor(
        private service: PagamentoService,
        private itemService: ItemService,
        private vendaService: VendaService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.service.list().subscribe((pg) => {
            this.array = pg;
        });
    }

    atualizar(val: any): void {
        this.pagamento = val.value.formaDePagamento;
    }

    create(): void {
        let carrinhoId = localStorage.getItem("carrinhoId")! || "";

        console.log("Entrou");
        this.itemService.getByCartId(carrinhoId).subscribe((itens: any) => {
            let venda: Venda = {
                pagamento: this.pagamento,
                itens: itens,
                cliente: this.usuario,
            };

            console.log(venda);

            this.vendaService.create(venda, carrinhoId).subscribe(() => {});

            this.router.navigate([""]);
        });
    }
}
