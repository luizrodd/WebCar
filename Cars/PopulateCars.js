const { chromium } = require('@playwright/test');
const fs = require('fs');

(async () => {
    const browser = await chromium.launch({ headless: false });
    const page = await browser.newPage();

    // Acessa a página principal de marcas
    await page.goto('https://tabelacarros.com/marcas/carros');

    // Extrai os links das marcas e seus nomes
    const marcas = await page.$$eval('.box_marcas_todas a', elementos =>
        elementos.map(el => ({
            nome: el.textContent.trim(),
            url: el.href
        })).filter(marca => ['Volkswagen'].includes(marca.nome)) // Filtra pelas marcas desejadas
    );

    const dadosCarros = [];

    // Loop para acessar cada marca
    for (const marca of marcas) {
        await page.goto(marca.url);

        // Extrai os links e nomes dos modelos
        const modelos = await page.$$eval('.box_todos_modelos a', elementos =>
            elementos.map(el => ({
                nome: el.querySelector('.modelo_base2').textContent.trim(),
                url: el.href
            }))
        );

        // Loop para acessar cada modelo dentro da marca
        for (const modelo of modelos) {
            await page.goto(modelo.url);

            // Extrai os links e informações das versões dos modelos
            const versoes = await page.$$eval('tr.link', elementos =>
                elementos.map(el => ({
                    ano: el.querySelector('.link_ano').textContent.trim(),
                    fipe: el.querySelectorAll('td')[1].textContent.trim(),
                    url: el.getAttribute('data-url')
                }))
            );

            // Loop para acessar cada versão e coletar as informações detalhadas
            for (const versao of versoes) {
                await page.goto(versao.url);

                const detalhes = await page.$$eval('tr.link', elementos =>
                    elementos.map(el => ({
                        ano: el.querySelector('.link_ano').textContent.trim(),
                        url: el.getAttribute('data-url')
                    }))
                );

                for (const detalhe of detalhes) {
                    await page.goto(detalhe.url);

                    // Extrai os dados da tabela de informações
                    const tabelaInfo = await page.$$eval('.info tbody tr', linhas => 
                        linhas.map(linha => {
                          const coluna1 = linha.querySelector('.coluna1')?.textContent.trim() || '';
                          const coluna2 = linha.querySelector('.coluna2')?.textContent.trim() || '';
                          return { coluna1, coluna2 };
                        })
                    );

                    // Cria um objeto para armazenar as informações do carro
                    const infoCarro = {
                        marca: marca.nome,
                        modelo: modelo.nome,
                        ano: detalhe.ano,
                        detalhes: {}
                    };

                    // Armazena as informações da tabela no objeto
                    tabelaInfo.forEach(info => {
                        infoCarro.detalhes[info.coluna1] = info.coluna2;
                    });

                    // Adiciona o objeto ao array principal
                    dadosCarros.push(infoCarro);
                }
            }
        }
    }

    // Salva o JSON em um arquivo
    fs.writeFileSync('Volkswagen.json', JSON.stringify(dadosCarros, null, 2), 'utf-8');
    console.log('Arquivo dadosCarros.json salvo com sucesso.');

    await browser.close();
})();
