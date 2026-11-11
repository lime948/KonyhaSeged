const INGREDIENTS = [
  { name: "Tojás", icon: "🥚" },
  { name: "Liszt", icon: "🌾" },
  { name: "Tej", icon: "🥛" },
  { name: "Sajt", icon: "🧀" },
  { name: "Csirkemell", icon: "🍗" },
  { name: "Paradicsom", icon: "🍅" },
  { name: "Burgonya", icon: "🥔" },
  { name: "Hagyma", icon: "🧅" },
  { name: "Rizs", icon: "🍚" },
  { name: "Tejföl", icon: "🥣" },
  { name: "Paprika", icon: "🫑" },
  { name: "Tészta", icon: "🍝" },
  { name: "Kukorica", icon: "🌽" },
  { name: "Uborka", icon: "🥒" },
  { name: "Fokhagyma", icon: "🧄" },
  { name: "Répa", icon: "🥕" }
];

const RECIPES = [
  {
    id: 1, name: "Sajtos omlett", emoji: "🍳", time: 15, difficulty: "Könnyű",
    description: "Gyors, laktató reggeli tojással és olvadó sajttal.",
    ingredients: ["tojás", "sajt", "tej", "hagyma"],
    steps: ["Verd fel a tojásokat egy kevés tejjel.", "Aprítsd fel a hagymát, majd kevés olajon párold meg.", "Öntsd rá a tojást, szórd meg sajttal, és süsd készre."]
  },
  {
    id: 2, name: "Paradicsomos tészta", emoji: "🍝", time: 25, difficulty: "Könnyű",
    description: "Egyszerű, ízletes tészta friss paradicsomos szósszal.",
    ingredients: ["tészta", "paradicsom", "hagyma", "fokhagyma", "sajt"],
    steps: ["Főzd meg a tésztát a csomagolás szerint.", "Pirítsd meg a hagymát és a fokhagymát, majd add hozzá a paradicsomot.", "Pár perc főzés után keverd össze a tésztával, és szórj rá sajtot."]
  },
  {
    id: 3, name: "Tepsis sajtos burgonya", emoji: "🥔", time: 40, difficulty: "Könnyű",
    description: "Aranybarnára sült burgonya sajtos feltéttel.",
    ingredients: ["burgonya", "sajt", "tejföl", "hagyma"],
    steps: ["Mosd meg és szeleteld fel a burgonyát.", "Tedd tepsibe, fűszerezd, majd süsd puhára.", "Keverd össze a tejfölt reszelt sajttal, kend a tetejére, és süsd még pár percig."]
  },
  {
    id: 4, name: "Csirkés rizs", emoji: "🍚", time: 30, difficulty: "Közepes",
    description: "Klasszikus, egyszerű egytálétel csirkemellel és zöldségekkel.",
    ingredients: ["csirkemell", "rizs", "hagyma", "paprika", "répa"],
    steps: ["Kockázd fel a csirkemellet és a zöldségeket.", "Pirítsd meg a hagymát, add hozzá a csirkét és a zöldségeket.", "Keverd hozzá a rizst és a szükséges mennyiségű vizet, majd főzd puhára."]
  },
  {
    id: 5, name: "Sós palacsinta", emoji: "🥞", time: 25, difficulty: "Könnyű",
    description: "Sokféleképpen tölthető, puha palacsinta.",
    ingredients: ["tojás", "liszt", "tej", "sajt"],
    steps: ["Keverd csomómentesre a tojást, lisztet és tejet.", "Pihentesd a tésztát néhány percig.", "Süss vékony palacsintákat, majd töltsd meg sajttal."]
  },
  {
    id: 6, name: "Tejfölös csirkemell", emoji: "🍗", time: 35, difficulty: "Közepes",
    description: "Krémes, fokhagymás-tejfölös csirke egyszerű fűszerezéssel.",
    ingredients: ["csirkemell", "tejföl", "fokhagyma", "sajt", "hagyma"],
    steps: ["Szeleteld fel a csirkemellet, és fűszerezd meg.", "Pirítsd meg a hagymát, majd süsd át rajta a csirkét.", "Keverd össze a tejfölt a fokhagymával, öntsd a húsra, szórd meg sajttal, majd süsd készre."]
  },
  {
    id: 7, name: "Zöldséges tojáslepény", emoji: "🥘", time: 20, difficulty: "Könnyű",
    description: "Színes, gyors serpenyős étel a megmaradt zöldségekből.",
    ingredients: ["tojás", "paradicsom", "paprika", "hagyma", "sajt"],
    steps: ["Vágd apróra a zöldségeket.", "Pirítsd meg őket egy serpenyőben.", "Öntsd rá a felvert tojást, szórd meg sajttal, és süsd készre."]
  },
  {
    id: 8, name: "Kukoricás-tejfölös tészta", emoji: "🍲", time: 20, difficulty: "Könnyű",
    description: "Krémes tészta néhány könnyen beszerezhető hozzávalóból.",
    ingredients: ["tészta", "kukorica", "tejföl", "sajt"],
    steps: ["Főzd meg a tésztát.", "Keverd össze a tejfölt a kukoricával és egy kevés fűszerrel.", "Forgasd össze a tésztával, majd szórd meg sajttal."]
  }
];

const ingredientGrid = document.getElementById("ingredientGrid");
const selectedCount = document.getElementById("selectedCount");
const customForm = document.getElementById("customIngredientForm");
const customInput = document.getElementById("customIngredient");
const searchButton = document.getElementById("searchButton");
const clearButton = document.getElementById("clearButton");
const formMessage = document.getElementById("formMessage");
const recipeGrid = document.getElementById("recipeGrid");
const resultsDescription = document.getElementById("resultsDescription");
const sortSelect = document.getElementById("sortSelect");
const recipeDialog = document.getElementById("recipeDialog");
const dialogContent = document.getElementById("dialogContent");
const dialogClose = document.getElementById("dialogClose");

let selectedIngredients = [];
let currentResults = [];

function normalize(value) {
  return value.trim().toLocaleLowerCase("hu-HU");
}

function renderIngredientOptions() {
  ingredientGrid.innerHTML = "";

  INGREDIENTS.forEach((ingredient) => {
    const label = document.createElement("label");
    label.className = "ingredient-option";
    label.innerHTML = `
      <input type="checkbox" value="${ingredient.name}">
      <span>${ingredient.icon}</span>
      <span>${ingredient.name}</span>
    `;

    const checkbox = label.querySelector("input");
    checkbox.checked = selectedIngredients.includes(normalize(ingredient.name));
    label.classList.toggle("selected", checkbox.checked);

    checkbox.addEventListener("change", () => {
      const value = normalize(ingredient.name);
      if (checkbox.checked && !selectedIngredients.includes(value)) {
        selectedIngredients.push(value);
      } else {
        selectedIngredients = selectedIngredients.filter(item => item !== value);
      }
      label.classList.toggle("selected", checkbox.checked);
      updateSelectedCount();
      formMessage.textContent = "";
    });

    ingredientGrid.appendChild(label);
  });
}

function updateSelectedCount() {
  selectedCount.textContent = `${selectedIngredients.length} kiválasztva`;
}

function addCustomIngredient(name) {
  const cleanName = normalize(name);
  if (!cleanName) return;

  if (selectedIngredients.includes(cleanName)) {
    formMessage.textContent = "Ez a hozzávaló már ki van választva.";
    return;
  }

  selectedIngredients.push(cleanName);

  renderIngredientOptions();

  if (!INGREDIENTS.some(item => normalize(item.name) === cleanName)) {
    const label = document.createElement("label");
    label.className = "ingredient-option selected";
    label.innerHTML = `<input type="checkbox" checked value=""><span>＋</span><span></span>`;
    label.querySelector("span:last-child").textContent = name.trim();
    label.querySelector("input").addEventListener("change", (event) => {
      if (!event.target.checked) {
        selectedIngredients = selectedIngredients.filter(item => item !== cleanName);
        label.remove();
        updateSelectedCount();
      }
    });
    ingredientGrid.appendChild(label);
  }

  updateSelectedCount();
  formMessage.textContent = `"${name.trim()}" hozzáadva.`;
}

function findMatchingRecipes() {
  const chosen = selectedIngredients;
  return RECIPES.map(recipe => {
    const recipeIngredients = recipe.ingredients.map(normalize);
    const matched = recipeIngredients.filter(item => chosen.includes(item));
    const missing = recipeIngredients.filter(item => !chosen.includes(item));
    return {
      ...recipe,
      matched,
      missing,
      matchCount: matched.length,
      matchPercent: Math.round((matched.length / recipeIngredients.length) * 100)
    };
  })
  .filter(recipe => recipe.matchCount > 0)
  .sort((a, b) => b.matchPercent - a.matchPercent || a.time - b.time);
}

function renderRecipes() {
  const sorted = [...currentResults];

  if (sortSelect.value === "time") {
    sorted.sort((a, b) => a.time - b.time || b.matchPercent - a.matchPercent);
  } else {
    sorted.sort((a, b) => b.matchPercent - a.matchPercent || a.time - b.time);
  }

  recipeGrid.innerHTML = "";

  if (sorted.length === 0) {
    recipeGrid.innerHTML = `
      <div class="empty-state">
        <span class="empty-icon">🧺</span>
        <h3>Most nem találtunk receptet</h3>
        <p>Próbálj meg más hozzávalókat kiválasztani, vagy adj hozzá még néhányat.</p>
      </div>`;
    return;
  }

  sorted.forEach(recipe => {
    const card = document.createElement("article");
    card.className = "recipe-card";

    const missingText = recipe.missing.length
      ? recipe.missing.map(capitalize).join(", ")
      : "Minden szükséges hozzávaló megvan!";

    card.innerHTML = `
      <div class="recipe-image" aria-hidden="true">${recipe.emoji}</div>
      <div class="recipe-card-content">
        <div class="recipe-meta">
          <span>${recipe.time} perc · ${recipe.difficulty}</span>
          <span class="match-pill">${recipe.matchPercent}% egyezés</span>
        </div>
        <h3></h3>
        <p></p>
        <div class="missing-label">HIÁNYZÓ HOZZÁVALÓK</div>
        <div class="missing-list"></div>
        <button type="button">Recept megtekintése →</button>
      </div>`;

    card.querySelector("h3").textContent = recipe.name;
    card.querySelector(".recipe-card-content > p").textContent = recipe.description;
    card.querySelector(".missing-list").textContent = missingText;
    card.querySelector("button").addEventListener("click", () => openRecipe(recipe));
    recipeGrid.appendChild(card);
  });
}

function capitalize(value) {
  return value.charAt(0).toLocaleUpperCase("hu-HU") + value.slice(1);
}

function openRecipe(recipe) {
  dialogContent.innerHTML = `
    <div class="dialog-emoji">${recipe.emoji}</div>
    <h2></h2>
    <p>${recipe.time} perc · ${recipe.difficulty} · ${recipe.matchPercent}% hozzávaló-egyezés</p>
    <h3>Hozzávalók</h3>
    <ul class="dialog-ingredients"></ul>
    <h3>Elkészítés</h3>
    <ol class="dialog-steps"></ol>`;

  dialogContent.querySelector("h2").textContent = recipe.name;

  recipe.ingredients.forEach(item => {
    const li = document.createElement("li");
    li.textContent = capitalize(item);
    dialogContent.querySelector(".dialog-ingredients").appendChild(li);
  });

  recipe.steps.forEach(step => {
    const li = document.createElement("li");
    li.textContent = step;
    dialogContent.querySelector(".dialog-steps").appendChild(li);
  });

  recipeDialog.showModal();
}

function searchRecipes() {
  if (selectedIngredients.length === 0) {
    formMessage.textContent = "A kereséshez válassz ki legalább egy hozzávalót!";
    return;
  }

  currentResults = findMatchingRecipes();
  resultsDescription.textContent =
    `${selectedIngredients.map(capitalize).join(", ")} – ${currentResults.length} recepttalálat.`;
  renderRecipes();
  document.getElementById("talalatok").scrollIntoView({ behavior: "smooth" });
  formMessage.textContent = "";
}

customForm.addEventListener("submit", (event) => {
  event.preventDefault();
  const value = customInput.value;
  if (!value.trim()) return;
  addCustomIngredient(value);
  customInput.value = "";
});

searchButton.addEventListener("click", searchRecipes);

clearButton.addEventListener("click", () => {
  selectedIngredients = [];
  currentResults = [];
  renderIngredientOptions();
  updateSelectedCount();
  formMessage.textContent = "";
  resultsDescription.textContent = "Válassz hozzávalókat, és megmutatjuk, mit készíthetsz belőlük.";
  recipeGrid.innerHTML = `
    <div class="empty-state">
      <span class="empty-icon">🥗</span>
      <h3>Jöhetnek a hozzávalók?</h3>
      <p>A keresés után itt jelennek meg a hozzávalóidhoz illő receptek.</p>
    </div>`;
});

sortSelect.addEventListener("change", renderRecipes);
dialogClose.addEventListener("click", () => recipeDialog.close());
recipeDialog.addEventListener("click", (event) => {
  if (event.target === recipeDialog) recipeDialog.close();
});

renderIngredientOptions();
updateSelectedCount();