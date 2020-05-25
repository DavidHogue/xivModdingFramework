using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using xivModdingFramework.General.Enums;
using xivModdingFramework.Items.DataContainers;
using xivModdingFramework.Items.Enums;
using xivModdingFramework.Models.DataContainers;
using xivModdingFramework.Models.FileTypes;
using Xunit;

namespace xivModdingFramework.Test.Models.FileTypes
{
    public class DaeTest
    {
        [Fact]
        public async Task Test()
        {
            var gameDirectory = new DirectoryInfo(@"D:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn\game\sqpack\ffxiv");
            var dataFile = XivDataFile._04_Chara;

            var mdl = new Mdl(gameDirectory, dataFile);
            var itemModel = new XivGear
            {
                Category = "Gear",
                DataFile = dataFile,
                EquipSlotCategory = 3,
                IconNumber = 40774,
                ItemCategory = "Head",
                ModelInfo = new XivModelInfo
                {
                    Body = 0,
                    ModelID = 9098,
                    ModelKey = new General.Quad { Value1 = 9098, Value2 = 5, Value3 = 0, Value4 = 0 },
                    ModelType = XivItemType.unknown,
                    Unused = 0,
                    Variant = 5
                },
                Name = "Adept's Hat",
                SecondaryModelInfo = new XivModelInfo
                {
                    Body = 0,
                    ModelID = 0,
                    ModelKey = new General.Quad(),
                    ModelType = XivItemType.unknown,
                    Unused = 0,
                    Variant = 0
                }
            };
            var originalMdl = await mdl.GetMdlData(itemModel, XivRace.Hyur_Midlander_Male, null, "chara/equipment/e9098/model/c0101e9098_met.mdl", 228432);

            var pluginTarget = "Autodesk Collada";
            var dae = new Dae(gameDirectory, dataFile, pluginTarget);

            var daeLocation = new DirectoryInfo(@"C:\Users\David Hogue\Desktop\1headpieceOpenCollada.DAE");
            var advImportSettings = new Dictionary<string, ModelImportSettings>
            {
                { "0", new ModelImportSettings { PartList = new List<int> { 0 } } },
                { "1", new ModelImportSettings { PartList = new List<int> { 0 } } }
            };
            var file = dae.ReadColladaFile(originalMdl, daeLocation, advImportSettings);

            Assert.Equal(12610, file[0][0].BoneIndices.Count);
            Assert.Equal(3, file[0][0].BoneNumDictionary.Count);
            Assert.Single(file[0][0].BoneWeights);
            Assert.Single(file[0][0].Bones);
            Assert.Equal(157536, file[0][0].Indices.Count);
            Assert.False(file[0][0].IsBlender);
            Assert.Single(file[0][0].MeshBoneNames);
            Assert.Equal(26256, file[0][0].NormalIndices.Count);
            Assert.Equal(18915, file[0][0].Normals.Count);
            Assert.Equal(26256, file[0][0].PositionIndices.Count);
            Assert.Equal(18915, file[0][0].Positions.Count);
            Assert.Equal(26256, file[0][0].TextureCoordinate0Indices.Count);
            Assert.Equal(26256, file[0][0].TextureCoordinate1Indices.Count);
            Assert.Equal(3, file[0][0].TextureCoordinateStride);
            Assert.Equal(18915, file[0][0].TextureCoordinates0.Count);
            Assert.Equal(18915, file[0][0].TextureCoordinates1.Count);
            Assert.Equal(6305, file[0][0].Vcounts.Count);
            Assert.Equal(26256, file[0][0].VertexAlphaIndices.Count);
            Assert.Equal(18915, file[0][0].VertexAlphas.Count);
            Assert.Equal(26256, file[0][0].VertexColorIndices.Count);
            Assert.Equal(3, file[0][0].VertexColorStride);
            Assert.Equal(78768, file[0][0].VertexColors.Count);

            Assert.Equal(800, file[1][0].BoneIndices.Count);
            Assert.Equal(3, file[1][0].BoneNumDictionary.Count);
            Assert.Single(file[1][0].BoneWeights);
            Assert.Single(file[1][0].Bones);
            Assert.Equal(6732, file[1][0].Indices.Count);
            Assert.False(file[1][0].IsBlender);
            Assert.Single(file[1][0].MeshBoneNames);
            Assert.Equal(1122, file[1][0].NormalIndices.Count);
            Assert.Equal(1200, file[1][0].Normals.Count);
            Assert.Equal(1122, file[1][0].PositionIndices.Count);
            Assert.Equal(1200, file[1][0].Positions.Count);
            Assert.Equal(1122, file[1][0].TextureCoordinate0Indices.Count);
            Assert.Equal(1122, file[1][0].TextureCoordinate1Indices.Count);
            Assert.Equal(3, file[1][0].TextureCoordinateStride);
            Assert.Equal(1200, file[1][0].TextureCoordinates0.Count);
            Assert.Equal(1200, file[1][0].TextureCoordinates1.Count);
            Assert.Equal(400, file[1][0].Vcounts.Count);
            Assert.Equal(1122, file[1][0].VertexAlphaIndices.Count);
            Assert.Equal(1200, file[1][0].VertexAlphas.Count);
            Assert.Equal(1122, file[1][0].VertexColorIndices.Count);
            Assert.Equal(3, file[1][0].VertexColorStride);
            Assert.Equal(3366, file[1][0].VertexColors.Count);

            Assert.Equal(800, file[1][1].BoneIndices.Count);
            Assert.Equal(3, file[1][1].BoneNumDictionary.Count);
            Assert.Single(file[1][1].BoneWeights);
            Assert.Single(file[1][1].Bones);
            Assert.Equal(6732, file[1][1].Indices.Count);
            Assert.False(file[1][1].IsBlender);
            Assert.Single(file[1][1].MeshBoneNames);
            Assert.Equal(1122, file[1][1].NormalIndices.Count);
            Assert.Equal(1200, file[1][1].Normals.Count);
            Assert.Equal(1122, file[1][1].PositionIndices.Count);
            Assert.Equal(1200, file[1][1].Positions.Count);
            Assert.Equal(1122, file[1][1].TextureCoordinate0Indices.Count);
            Assert.Equal(1122, file[1][1].TextureCoordinate1Indices.Count);
            Assert.Equal(3, file[1][1].TextureCoordinateStride);
            Assert.Equal(1200, file[1][1].TextureCoordinates0.Count);
            Assert.Equal(1200, file[1][1].TextureCoordinates1.Count);
            Assert.Equal(400, file[1][1].Vcounts.Count);
            Assert.Equal(1122, file[1][1].VertexAlphaIndices.Count);
            Assert.Equal(1200, file[1][1].VertexAlphas.Count);
            Assert.Equal(1122, file[1][1].VertexColorIndices.Count);
            Assert.Equal(3, file[1][1].VertexColorStride);
            Assert.Equal(3366, file[1][1].VertexColors.Count);
        }
    }
}
