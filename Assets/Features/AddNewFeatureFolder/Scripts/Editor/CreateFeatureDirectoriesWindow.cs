using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Features.AddNewFeatureFolder.Scripts.Editor
{
    public class CreateFeatureDirectoriesWindow : EditorWindow
    {
        private string _featureToCreate;
        private bool _showDirectorySetUp;
        private FeatureDirectory _scriptsDirectory;
        private FeatureDirectory _testDirectory;
        private float _windowWidth;
        private Vector2 _scriptsScrollPosition;

        [MenuItem("Window/Dummy/CreateFeatureDirectorie %g")]
        public static void ShowWindow() => GetWindow(typeof(CreateFeatureDirectoriesWindow),true,nameof(CreateFeatureDirectoriesWindow));

        private void Awake() => SetUpFeatureCreationProfile();

        private void OnValidate()
        {
            if (_scriptsDirectory == null || _testDirectory == null)
                SetUpFeatureCreationProfile();
        }

        private void OnGUI()
        {
            UpdateWidth();
            DrawDirectoryCreation();
            DrawDirectorySetUp();
        }

        private void DrawDirectoryCreation()
        {
            EditorGUILayout.BeginVertical();
            
            DrawFeatureInputField();
            
            if (GUILayout.Button("Create"))
            {
                var desiredFeatureDirectory = Path.Combine(Application.dataPath, "Features", _featureToCreate);
                if (!Directory.Exists(desiredFeatureDirectory))
                {
                    CreateDirectoryTree(desiredFeatureDirectory, _scriptsDirectory);
                    CreateDirectoryTree(desiredFeatureDirectory, _testDirectory);
                }
                
                else Debug.LogError("Trying to create a feature folder that already exists!");
            }

            EditorGUILayout.EndVertical();
            void DrawFeatureInputField()
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Name of the feature", GUILayout.Width(_windowWidth / 2));
                _featureToCreate = EditorGUILayout.TextField(_featureToCreate, GUILayout.Width(_windowWidth / 2));
                EditorGUILayout.EndHorizontal();
            }
        }

        private void CreateDirectoryTree(string parentPath, FeatureDirectory currentDirectory)
        {
            if (!currentDirectory.createDirectory) return;
            var currentPath = UpdatePath();
            CreateDirectory(currentPath);
            CheckForAsmdefCreation();
            CheckForGitKeepCreation();
            foreach (var subDirectory in currentDirectory.subDirectories)
                CreateDirectoryTree(currentPath, subDirectory);

            string UpdatePath() => Path.Combine(parentPath, currentDirectory.name);
            void CreateDirectory(string directory) => Directory.CreateDirectory(directory);
            void CheckForAsmdefCreation()
            {
                var asmdefConfiguration = currentDirectory.asmdefConfiguration;
                if (asmdefConfiguration.createAsmdef)
                    CreateAsmdefFile(currentPath, asmdefConfiguration.assemblyName + _featureToCreate);
            }
            void CreateAsmdefFile(string scriptsDirectory, string asmdefName)
            {
                using (var stream = File.Create(scriptsDirectory + $"/{asmdefName}.asmdef"))
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("{");
                    sb.AppendLine(@"""name"":" + $"\"{asmdefName}\"");
                    sb.Append("}");
                    stream.Write(new UTF8Encoding(true).GetBytes(sb.ToString()));
                }
            }
            void CheckForGitKeepCreation()
            {
                if (currentDirectory.subDirectories.Count == 0) CreateGitKeepFile(currentPath);
            }
            void CreateGitKeepFile(string directory) => File.Create(directory + "/.gitkeep");
        }
        private void DrawDirectorySetUp()
        {
            _showDirectorySetUp = EditorGUILayout.Foldout(_showDirectorySetUp, "Custom Directory Profiles");
            
            if (!_showDirectorySetUp) return;
            
            _scriptsScrollPosition = EditorGUILayout.BeginScrollView(_scriptsScrollPosition);
            DrawDirectory(_scriptsDirectory, 0);
            DrawDirectory(_testDirectory, 0);
            EditorGUILayout.EndScrollView();
        }
        private static void DrawDirectory(FeatureDirectory directory, int depth)
        {
            var currentDirectory = directory;
            var space = depth * 15;

            GUILayout.BeginVertical("Box", GUILayout.Width(100));
            DrawStateName();
            if (WantsToCreateDirectory())
            { 
                DrawStateAsmdefConfiguration(); 
                DrawSubDirectories();
            }
            EditorGUILayout.EndVertical();

            void DrawStateName()
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(space);
                currentDirectory.createDirectory = EditorGUILayout.ToggleLeft(currentDirectory.name, currentDirectory.createDirectory);
                GUILayout.EndHorizontal();
            }
            bool WantsToCreateDirectory() => directory.createDirectory;
            void DrawStateAsmdefConfiguration()
            {
                if (!currentDirectory.createDirectory) return;
                var asmdefConfiguration = currentDirectory.asmdefConfiguration;
                DrawAsmdefCreationState(asmdefConfiguration);
                DrawAsmdefCustomName(asmdefConfiguration);
            }
            void DrawAsmdefCreationState(AsmdefConfiguration asmdefConfiguration)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(space);
                asmdefConfiguration.createAsmdef = EditorGUILayout.ToggleLeft("Create Assembly", asmdefConfiguration.createAsmdef);
                GUILayout.EndHorizontal();
            }
            void DrawAsmdefCustomName(AsmdefConfiguration asmdefConfiguration)
            {
                if (!asmdefConfiguration.createAsmdef) return;
                
                GUILayout.BeginHorizontal();
                GUILayout.Space(space);
                if (asmdefConfiguration.createAsmdef)
                    asmdefConfiguration.assemblyName = EditorGUILayout.TextField(asmdefConfiguration.assemblyName);
                GUILayout.EndHorizontal();
            }
            void DrawSubDirectories()
            {
                foreach (var subdirectory in currentDirectory.subDirectories)
                    DrawDirectory(subdirectory, depth + 1);
            }
        }
        private void SetUpFeatureCreationProfile()
        {
            _scriptsDirectory = CreateScriptsDirectory();
            _testDirectory = CreateTestDirectory();
        }
        private static FeatureDirectory CreateScriptsDirectory()
        {
            var domainDirectory = new FeatureDirectory("Domain", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var presentationDirectory = new FeatureDirectory("Presentation", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var infrastructureDirectory = new FeatureDirectory("Infrastructure", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var deliveryDirectory = new FeatureDirectory("Delivery", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var providerDirectory = new FeatureDirectory("Provider", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var editorDirectory = new FeatureDirectory("Editor", true, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var scriptsDirectory = new FeatureDirectory("Scripts", true,
                    new AsmdefConfiguration { createAsmdef = true, assemblyName = "Dummy_" },
                    new List<FeatureDirectory>
                    {
                        domainDirectory, presentationDirectory,
                        infrastructureDirectory, deliveryDirectory,
                        providerDirectory, editorDirectory
                    });
            return scriptsDirectory;
        }
        private static FeatureDirectory CreateTestDirectory()
        {
            var domainDirectory = new FeatureDirectory("Domain", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var presentationDirectory = new FeatureDirectory("Presentation", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var infrastructureDirectory = new FeatureDirectory("Infrastructure", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var deliveryDirectory = new FeatureDirectory("Delivery", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var providerDirectory = new FeatureDirectory("Provider", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var editorDirectory = new FeatureDirectory("Editor", false, new AsmdefConfiguration(), new List<FeatureDirectory>());
            var scriptsDirectory = new FeatureDirectory("Test", true, new AsmdefConfiguration { createAsmdef = true, assemblyName = "Dummy_Test_" },
                    new List<FeatureDirectory>
                    {
                        domainDirectory, presentationDirectory,
                        infrastructureDirectory, deliveryDirectory,
                        providerDirectory, editorDirectory
                    });
            return scriptsDirectory;
        }
        private void UpdateWidth() => _windowWidth = EditorGUIUtility.currentViewWidth;
    }
}

public class FeatureDirectory
{
    public string name;
    public bool createDirectory;
    public AsmdefConfiguration asmdefConfiguration;
    public List<FeatureDirectory> subDirectories;

    public FeatureDirectory(string name, bool createDirectory, AsmdefConfiguration asmdefConfiguration,
                            List<FeatureDirectory> subDirectories)
    {
        this.name = name;
        this.createDirectory = createDirectory;
        this.asmdefConfiguration = asmdefConfiguration;
        this.subDirectories = subDirectories;
    }
}

public class AsmdefConfiguration
{
    public bool createAsmdef;
    public string assemblyName;
}