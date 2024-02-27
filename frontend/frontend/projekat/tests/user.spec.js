const {test,expect}=require('@playwright/test')

test('My first test',async ({page})=>{
   
    await page.goto('http://localhost:4200/login')
      // Unesi korisničko ime i lozinku
      await page.fill('input[placeholder="Username"]', 'petar');
      await page.fill('input[placeholder="Password"]', 'petar');
  
      // Klikni na dugme za login
      await page.click('.btn');
  
      // Sačekaj da se stranica ažurira nakon klika na dugme
      await page.waitForNavigation();
  
      // Proveri da li je korisnik uspešno prijavljen (očekujemo neki element koji pokazuje da je korisnik ulogovan)
      await page.waitForURL('http://localhost:4200/userprofile', { timeout: 5000 });  // Zamijenite URL-om odredišne stranice
      const currentURL = page.url();
      await expect(currentURL).toBe('http://localhost:4200/userprofile'); 

})