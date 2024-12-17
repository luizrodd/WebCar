const fs = require('fs');

// Caminho do arquivo de entrada e saída
const inputFile = 'Volkswagen.json';
const outputFile = 'VolkswagenCleanDatra.json';

// Função para remover objetos duplicados com base no campo "versao"
function removeDuplicates(data) {
  const seenVersions = new Set(); // Armazena as versões já encontradas
  return data.filter(item => {
    if (seenVersions.has(item.versao)) {
      return false; // Remove o item duplicado
    }
    seenVersions.add(item.versao);
    return true; // Mantém o item único
  });
}

// Função principal para tratar o arquivo
function processFile(inputFile, outputFile) {
  try {
    // Lê o arquivo de entrada
    const rawData = fs.readFileSync(inputFile, 'utf-8');
    const inputData = JSON.parse(rawData);

    // Remove duplicados
    const cleanedData = removeDuplicates(inputData);

    // Salva o resultado no arquivo de saída
    fs.writeFileSync(outputFile, JSON.stringify(cleanedData, null, 2), 'utf-8');

    console.log(`Arquivo tratado e salvo em: ${outputFile}`);
  } catch (error) {
    console.error('Erro ao processar o arquivo:', error.message);
  }
}

// Executa a função com os arquivos especificados
processFile(inputFile, outputFile);
