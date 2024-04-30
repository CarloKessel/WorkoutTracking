const fs = require('fs');

// Read the original Artillery YAML file
const originalYaml = fs.readFileSync('Artillery-Load-Tests-Get-Endpoints.yml', 'utf8');

// Replace the placeholder with the actual secret value
const replacedYaml = originalYaml.replace(/\${{ secrets.AUTH_TEST_TOKEN }}/g, "AUTH_TOKEN");

console.log(replacedYaml);
console.log('-----------------------------------');
console.log(/\${{ secrets.AUTH_TEST_TOKEN }}/g);

// Write the modified YAML to a new file
fs.writeFileSync('Artillery-Load-Tests-Get-Endpoints-modified.yml', replacedYaml);

console.log('Secret injected successfully!');